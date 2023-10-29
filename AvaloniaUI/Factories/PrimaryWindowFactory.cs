using MochaMothMedia.MochaMaker.AvaloniaUI.Templates;
using MochaMothMedia.MochaMaker.Core.UI.Drawables;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Windows;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
	public class PrimaryWindowFactory : IPrimaryWindowFactory
	{
		public IWindow Create()
		{
			return new PrimaryWindow();
		}
	}
}
