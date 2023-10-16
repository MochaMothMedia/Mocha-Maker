using MochaMothMedia.MochaMaker.AvaloniaUI.Templates;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panes;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
	public class SplitPaneFactory : ISplitPaneFactory
	{
		public ISplitPane Create()
		{
			return new SplitPane();
		}
	}
}
