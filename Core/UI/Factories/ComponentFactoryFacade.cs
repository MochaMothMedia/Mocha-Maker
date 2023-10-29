using MochaMothMedia.MochaMaker.Core.UI.Drawables;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Components;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Windows;

namespace MochaMothMedia.MochaMaker.Core.UI.Factories
{
    public class ComponentFactoryFacade : IComponentFactory
    {
        private readonly ILabelFactory _labelFactory;
        private readonly IComponentPaneFactory _paneFactory;
        private readonly ISplitPaneFactory _splitPanelFactory;
		private readonly ITabbedPaneFactory _tabbedPaneFactory;
		private readonly IPopupWindowFactory _popupWindowFactory;
		private readonly IConfirmationWindowFactory _confirmationWindowFactory;
		private readonly IPrimaryWindowFactory _primaryWindowFactory;

		public ComponentFactoryFacade(
            ILabelFactory labelFactory,
            IComponentPaneFactory paneFactory,
            ISplitPaneFactory splitPanelFactory,
            ITabbedPaneFactory tabbedPaneFactory,
            IPopupWindowFactory popupWindowFactory,
            IConfirmationWindowFactory confirmationWindowFactory,
            IPrimaryWindowFactory primaryWindowFactory)
        {
            _labelFactory = labelFactory;
            _paneFactory = paneFactory;
            _splitPanelFactory = splitPanelFactory;
			_tabbedPaneFactory = tabbedPaneFactory;
			_popupWindowFactory = popupWindowFactory;
			_confirmationWindowFactory = confirmationWindowFactory;
			_primaryWindowFactory = primaryWindowFactory;
		}

        public ILabel CreateLabelComponent() => _labelFactory.Create();
        public IComponentPane CreateComponentPane() => _paneFactory.Create();
        public ISplitPane CreateSplitPane() => _splitPanelFactory.Create();
        public ITabbedPane CreateTabbedPane() => _tabbedPaneFactory.Create();
        public IPopupWindow CreatePopupWindow() => _popupWindowFactory.Create();
        public IConfirmationWindow CreateConfirmationWindow() => _confirmationWindowFactory.Create();
        public IWindow CreatePrimaryWindow() => _primaryWindowFactory.Create();
    }
}
