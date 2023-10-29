using MochaMothMedia.MochaMaker.Core.UI.Drawables;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;

namespace MochaMothMedia.MochaMaker.Core.UI
{
    public interface IComponentFactory
	{
		ILabel CreateLabelComponent();
		IComponentPane CreateComponentPane();
		ISplitPane CreateSplitPane();
		ITabbedPane CreateTabbedPane();
		IPopupWindow CreatePopupWindow();
		IConfirmationWindow CreateConfirmationWindow();
		IWindow CreatePrimaryWindow();
	}
}
