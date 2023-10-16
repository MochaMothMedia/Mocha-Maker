namespace MochaMothMedia.MochaMaker.Core.UI
{
	public interface ILayoutSerializer
	{
		void SerializeLayout(IDrawable root, string fileName);
		IDrawable? DeserializeLayout(string fileName);
	}
}
