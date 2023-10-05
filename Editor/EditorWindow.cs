using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;
using MochaMothMedia.MochaMaker.UI.Core;

namespace MochaMothMedia.MochaMaker.Editor
{
    public class EditorWindow : IEditorWindow
	{
		IComponent _root;

		public EditorWindow(IComponentFactory componentFactory)
		{
			ISplitPanelComponent mainSplit = componentFactory.CreateSplitPanelComponent();
			ISplitPanelComponent consoleSplit = componentFactory.CreateSplitPanelComponent();

			ILabelComponent assetViewLabel = componentFactory.CreateLabelComponent();
			ILabelComponent hierarchyViewLabel = componentFactory.CreateLabelComponent();
			ILabelComponent entityViewerLabel = componentFactory.CreateLabelComponent();
			ILabelComponent consoleViewerLabel = componentFactory.CreateLabelComponent();
			ILabelComponent entityPropertiesViewerLabel = componentFactory.CreateLabelComponent();

			assetViewLabel.Label = "assetView";
			hierarchyViewLabel.Label = "hierarchyView";
			entityViewerLabel.Label = "entityViewer";
			consoleViewerLabel.Label = "consoleViewer";
			entityPropertiesViewerLabel.Label = "entityPropertiesViewer";

			consoleSplit.AddComponentAt(0, entityViewerLabel);
			consoleSplit.AddComponentAt(1, consoleViewerLabel);
			consoleSplit.SplitDirection = SplitDirection.Vertical;

			mainSplit.AddComponentAt(0, assetViewLabel);
			mainSplit.AddComponentAt(1, hierarchyViewLabel);
			mainSplit.AddComponentAt(2, consoleSplit);
			mainSplit.AddComponentAt(3, entityPropertiesViewerLabel);

			_root = mainSplit;
		}

		public IComponent GetRoot()
		{
			return _root;
		}
	}
}
