using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;

namespace MochaMothMedia.MochaMaker.Core.UI
{
    public interface IComponentFactory
	{
		ILabel CreateLabelComponent();
		IComponentPane CreateComponentPane();
		ISplitPane CreateSplitPane();
		ITabbedPane CreateTabbedPane();
	}
}
