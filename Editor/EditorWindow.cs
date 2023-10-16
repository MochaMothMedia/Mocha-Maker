using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;
using MochaMothMedia.MochaMaker.UI.Core;

namespace MochaMothMedia.MochaMaker.Editor
{
    public class EditorWindow : IEditorWindow
	{
		IComponent _root;
		private readonly ILayoutSerializer _layoutSerializer;

		public EditorWindow(IComponentFactory componentFactory, ILayoutSerializer layoutSerializer)
		{
			_layoutSerializer = layoutSerializer;

			IComponent? loadedRoot = _layoutSerializer.DeserializeLayout("Test");

			if (loadedRoot != null)
			{
				_root = loadedRoot;
				return;
			}

			LoadDefaultLayout(componentFactory);
		}

		private void LoadDefaultLayout(IComponentFactory componentFactory)
		{
			ISplitPanelComponent topMenuSplit = componentFactory.CreateSplitPanelComponent();
			ISplitPanelComponent mainSplit = componentFactory.CreateSplitPanelComponent();
			ISplitPanelComponent consoleSplit = componentFactory.CreateSplitPanelComponent();

			ILabelComponent commandAreaLabel = componentFactory.CreateLabelComponent();
			ILabelComponent assetViewLabel = componentFactory.CreateLabelComponent();
			ILabelComponent hierarchyViewLabel = componentFactory.CreateLabelComponent();
			ILabelComponent entityViewerLabel = componentFactory.CreateLabelComponent();
			ILabelComponent consoleViewerLabel = componentFactory.CreateLabelComponent();
			ILabelComponent entityPropertiesViewerLabel = componentFactory.CreateLabelComponent();

			commandAreaLabel.Label = "commandArea";
			assetViewLabel.Label = "assetView";
			hierarchyViewLabel.Label = "hierarchyView";
			entityViewerLabel.Label = "entityViewer";
			consoleViewerLabel.Label = "consoleViewer";
			entityPropertiesViewerLabel.Label = "entityPropertiesViewer";

			consoleSplit.AddComponent(entityViewerLabel);
			consoleSplit.AddComponent(consoleViewerLabel, 200);
			consoleSplit.SplitDirection = SplitDirection.Vertical;

			mainSplit.AddComponent(assetViewLabel, 200);
			mainSplit.AddComponent(hierarchyViewLabel, 200);
			mainSplit.AddComponent(consoleSplit);
			mainSplit.AddComponent(entityPropertiesViewerLabel, 400);

			topMenuSplit.AddComponent(commandAreaLabel, 100);
			topMenuSplit.AddComponent(mainSplit);
			topMenuSplit.SplitDirection = SplitDirection.Vertical;

			_root = topMenuSplit;
		}

		public IComponent GetRoot()
		{
			return _root;
		}

		public void OnClose()
		{
			_layoutSerializer.SerializeLayout(_root, "Test");
		}
	}
}
