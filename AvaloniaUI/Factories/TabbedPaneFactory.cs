using MochaMothMedia.MochaMaker.AvaloniaUI.Templates.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panes;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
	public class TabbedPaneFactory : ITabbedPaneFactory
	{
		public ITabbedPane Create()
		{
			return new TabbedPane();
		}
	}
}
