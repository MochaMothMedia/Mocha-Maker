using MochaMothMedia.MochaMaker.AvaloniaUI.Templates.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panes;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
    public class ComponentPaneFactory : IComponentPaneFactory
	{
		public IComponentPane Create()
		{
			ComponentPane panel = new ComponentPane();

			return panel;
		}
	}
}
