namespace MochaMothMedia.MochaMaker.Core
{
	public interface ISerializationTools
	{
		Dictionary<string, object?> SerializeObject(object obj);
		T? DeserializeObject<T>(Dictionary<string, object?> dict);
	}
}
