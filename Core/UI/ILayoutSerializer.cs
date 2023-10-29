using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;

namespace MochaMothMedia.MochaMaker.Core.UI
{
	public interface ILayoutSerializer
	{
		void SerializeLayout(WindowSet layout, string fileName);
		WindowSet? DeserializeLayout(string fileName);
	}
}
