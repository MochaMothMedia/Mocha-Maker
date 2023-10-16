using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Components;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panes;

namespace MochaMothMedia.MochaMaker.Core.UI.Factories
{
    public class ComponentFactoryFacade : IComponentFactory
    {
        private readonly ILabelFactory _labelFactory;
        private readonly IComponentPaneFactory _paneFactory;
        private readonly ISplitPaneFactory _splitPanelFactory;
		private readonly ITabbedPaneFactory _tabbedPaneFactory;

		public ComponentFactoryFacade(
            ILabelFactory labelFactory,
            IComponentPaneFactory paneFactory,
            ISplitPaneFactory splitPanelFactory,
            ITabbedPaneFactory tabbedPaneFactory)
        {
            _labelFactory = labelFactory;
            _paneFactory = paneFactory;
            _splitPanelFactory = splitPanelFactory;
			_tabbedPaneFactory = tabbedPaneFactory;
		}

        public ILabel CreateLabelComponent() => _labelFactory.Create();
        public IComponentPane CreateComponentPane() => _paneFactory.Create();
        public ISplitPane CreateSplitPane() => _splitPanelFactory.Create();
        public ITabbedPane CreateTabbedPane() => _tabbedPaneFactory.Create();
    }
}
