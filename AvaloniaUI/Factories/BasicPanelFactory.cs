using MochaMothMedia.MochaMaker.AvaloniaUI.Templates;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panels;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
    public class BasicPanelFactory : IBasicPanelFactory
	{
		public IPanelComponent Create()
		{
			BasicPanel panel = new BasicPanel();

			return panel;
		}
	}
}
