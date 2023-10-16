namespace MochaMothMedia.MochaMaker.Core.UI
{
	public interface ILayoutSerializer
	{
		void SerializeLayout(IComponent root, string fileName);
		IComponent? DeserializeLayout(string fileName);
	}
}
