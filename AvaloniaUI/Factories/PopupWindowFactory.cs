using MochaMothMedia.MochaMaker.AvaloniaUI.Templates;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Windows;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
	public class PopupWindowFactory : IPopupWindowFactory
	{
		public IPopupWindow Create()
		{
			return new PopupWindow();
		}
	}
}
