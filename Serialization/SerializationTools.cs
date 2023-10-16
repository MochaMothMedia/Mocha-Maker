using MochaMothMedia.MochaMaker.Core;
using System.Collections;
using System.Reflection;

namespace MochaMothMedia.MochaMaker.Serialization
{
	public class SerializationTools : ISerializationTools
	{
		public Dictionary<string, object?> SerializeObject(object obj)
		{
			Dictionary<string, object?> result = new Dictionary<string, object?>()
			{
				{ "$type", obj.GetType().AssemblyQualifiedName }
			};

			foreach (PropertyInfo property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
			{
				if (!property.CanRead)
					continue;

				object? value = property.GetValue(obj);

				if (value == null)
				{
					result.Add(property.Name, null);
					continue;
				}

				if (value is IList items)
				{
					List<object?> list = new List<object?>();

					foreach (var item in items)
					{
						if (IsNumericType(item.GetType()))
							list.Add(Convert.ChangeType(item, item.GetType()));
						else if (property.PropertyType.IsEnum)
							list.Add(value.ToString());
						else if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
							list.Add(Convert.ChangeType(value, property.PropertyType));
						else
							list.Add(SerializeObject(item));
					}

					result.Add(property.Name, list);
					continue;
				}

				if (property.PropertyType.IsEnum)
				{
					result.Add(property.Name, value.ToString());
					continue;
				}

				if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
				{
					result.Add(property.Name, Convert.ChangeType(value, property.PropertyType));
					continue;
				}

				result.Add(property.Name, SerializeObject(value));
			}

			return result;
		}

		public T? DeserializeObject<T>(Dictionary<string, object?> propertyMap)
		{
			if (propertyMap == null)
				return default;

			return (T?)DeserializeObjectByType(typeof(T), propertyMap);
		}

		private object? DeserializeObjectByType(Type targetType, Dictionary<string, object?> propertyMap)
		{
			Type definedType = GetDefinedType(propertyMap, targetType);
			object ? obj = Activator.CreateInstance(definedType);

			foreach (KeyValuePair<string, object?> keyValuePair in propertyMap)
			{
				PropertyInfo? property = definedType.GetProperty(keyValuePair.Key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

				if (property == null || !property.CanWrite)
					continue;

				if (keyValuePair.Value is Dictionary<string, object?> nestedDict)
				{
					MethodInfo? method = typeof(SerializationTools)?.GetMethod("DeserializeObjectByType")?.MakeGenericMethod(property.PropertyType);
					object? value = method?.Invoke(this, new[] { nestedDict });
					property.SetValue(obj, value);
					continue;
				}

				if (keyValuePair.Value is IList items && IsGenericListOrArray(property.PropertyType))
				{
					Type itemType;
					Type listType;

					if (property.PropertyType.IsArray)
					{
						itemType = property.PropertyType.GetElementType()!;
						listType = typeof(List<>).MakeGenericType(itemType);
					}
					else
					{
						itemType = property.PropertyType.GetGenericArguments().First();
						listType = property.PropertyType;
					}

					IList? list = Activator.CreateInstance(listType) as IList;

					if (list == null)
						continue;

					foreach (object? item in items)
					{
						if (item.GetType() == typeof(string))
						{
							try
							{
								list.Add(Convert.ChangeType(item, itemType));
								continue;
							}
							catch { }
						}

						if (property.PropertyType.IsEnum)
							list.Add(Enum.Parse(property.PropertyType, (string)item));

						else if (property.PropertyType.IsPrimitive)
							list.Add(Convert.ChangeType(item, property.PropertyType));

						else if (item is Dictionary<object, object?> itemObjectMap)
						{
							Dictionary<string, object?> itemPropertyMap = new Dictionary<string, object?>();

							foreach (KeyValuePair<object, object?> itemSet in itemObjectMap)
								if (itemSet.Key is string keyString)
									itemPropertyMap.Add(keyString, itemSet.Value);

							list.Add(DeserializeObjectByType(itemType, itemPropertyMap));
						}
					}

					if (property.PropertyType.IsArray)
					{
						Array array = Array.CreateInstance(itemType, list.Count);
						list.CopyTo(array, 0);
						property.SetValue(obj, array);
					}
					else
						property.SetValue(obj, list);
					continue;
				}

				if (property.PropertyType.IsEnum && keyValuePair.Value != null && !string.IsNullOrEmpty(keyValuePair.Value.ToString()))
				{
					property.SetValue(obj, Enum.Parse(property.PropertyType, keyValuePair.Value.ToString()!));
					continue;
				}

				property.SetValue(obj, keyValuePair.Value);
			}

			return obj;
		}

		private Type GetDefinedType(Dictionary<string, object?> propertyMap, Type defaultType)
		{
			if (propertyMap.ContainsKey("$type") && !string.IsNullOrEmpty(propertyMap["$type"] as string))
				return Type.GetType((propertyMap["$type"] as string)!) ?? defaultType;
			return defaultType;
		}

		private bool IsNumericType(Type type)
		{
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Byte:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.SByte:
				case TypeCode.Single:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					return true;
				default:
					return false;
			}
		}

		private bool IsGenericListOrArray(Type type)
		{
			return (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>))) || type.IsArray;
		}
	}
}