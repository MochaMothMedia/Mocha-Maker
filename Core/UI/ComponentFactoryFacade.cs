using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;
using MochaMothMedia.MochaMaker.Core.UI.Factories;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panels;

namespace MochaMothMedia.MochaMaker.Core.UI
{
    public class ComponentFactoryFacade : IComponentFactory
	{
		private readonly ILabelFactory _labelFactory;
		private readonly IBasicPanelFactory _panelFactory;
		private readonly ISplitPanelFactory _splitPanelFactory;

		public ComponentFactoryFacade(
			ILabelFactory labelFactory,
			IBasicPanelFactory panelFactory,
			ISplitPanelFactory splitPanelFactory)
		{
			_labelFactory = labelFactory;
			_panelFactory = panelFactory;
			_splitPanelFactory = splitPanelFactory;
		}

		public ILabelComponent CreateLabelComponent() => _labelFactory.Create();
		public IPanelComponent CreateBasicPanelComponent() => _panelFactory.Create();
		public ISplitPanelComponent CreateSplitPanelComponent() => _splitPanelFactory.Create();
	}
}
