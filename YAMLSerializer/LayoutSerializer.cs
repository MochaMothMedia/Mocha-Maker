using MochaMothMedia.MochaMaker.Core;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace MochaMothMedia.MochaMaker.YAMLSerializer
{
	public class LayoutSerializer : ILayoutSerializer
	{
		readonly string _rootDirectory;
		readonly ISerializer _serializer;
		readonly IDeserializer _deserializer;
		private readonly ISerializationTools _serializationTools;

		string LayoutDirectory => $"{_rootDirectory}/Mocha Maker/Layouts";

		public LayoutSerializer(ISerializationTools serializationTools)
		{
			_rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			_serializationTools = serializationTools;
			_serializer = new SerializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();
			_deserializer = new DeserializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();
		}

		public void SerializeLayout(WindowSet layout, string fileName)
		{
			if (layout == null)
				return;

			Dictionary<string, object?>? data =  _serializationTools.SerializeObject(layout);

			if (data == null)
				return;

			string serializedData = _serializer.Serialize(data);

			Directory.CreateDirectory(LayoutDirectory);

			File.WriteAllText($"{LayoutDirectory}/{fileName}.layout", serializedData);
		}

		public WindowSet? DeserializeLayout(string fileName)
		{
			if (!Directory.Exists(LayoutDirectory) || !File.Exists($"{LayoutDirectory}/{fileName}.layout"))
				return null;

			string serializedData = File.ReadAllText($"{LayoutDirectory}/{fileName}.layout");

			Dictionary<string, object?>? data = _deserializer.Deserialize<Dictionary<string, object?>?>(serializedData);

			if (data == null)
				return null;

			return _serializationTools.DeserializeObject<WindowSet>(data);
		}
	}
}
