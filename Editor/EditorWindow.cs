using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;
using MochaMothMedia.MochaMaker.UI.Core;

namespace MochaMothMedia.MochaMaker.Editor
{
    public class EditorWindow : IEditorWindow
	{
		private IComponent _root;
		private readonly IComponentFactory _componentFactory;
		private readonly ILayoutSerializer _layoutSerializer;

		public EditorWindow(IComponentFactory componentFactory, ILayoutSerializer layoutSerializer)
		{
			_componentFactory = componentFactory;
			_layoutSerializer = layoutSerializer;

			_root = LoadLayout();
		}

		private IComponent LoadLayout()
		{
			IComponent? loadedRoot = _layoutSerializer.DeserializeLayout("Test");

			if (loadedRoot == null)
				return LoadDefaultLayout();

			return loadedRoot;
		}

		private IComponent LoadDefaultLayout()
		{
			ISplitPanelComponent topMenuSplit = _componentFactory.CreateSplitPanelComponent();
			ISplitPanelComponent mainSplit = _componentFactory.CreateSplitPanelComponent();
			ISplitPanelComponent consoleSplit = _componentFactory.CreateSplitPanelComponent();

			ILabelComponent commandAreaLabel = _componentFactory.CreateLabelComponent();
			ILabelComponent assetViewLabel = _componentFactory.CreateLabelComponent();
			ILabelComponent hierarchyViewLabel = _componentFactory.CreateLabelComponent();
			ILabelComponent entityViewerLabel = _componentFactory.CreateLabelComponent();
			ILabelComponent consoleViewerLabel = _componentFactory.CreateLabelComponent();
			ILabelComponent entityPropertiesViewerLabel = _componentFactory.CreateLabelComponent();

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

			return topMenuSplit;
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
