using MochaMothMedia.MochaMaker.Core.Menu;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Drawables;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;

namespace MochaMothMedia.MochaMaker.Editor
{
    public class EditorWindow : IEditorWindow
	{
		public WindowSet Layout { get; set; } = new WindowSet();

		private readonly IComponentFactory _componentFactory;
		private readonly ILayoutSerializer _layoutSerializer;

		public EditorWindow(IComponentFactory componentFactory, ILayoutSerializer layoutSerializer)
		{
			_componentFactory = componentFactory;
			_layoutSerializer = layoutSerializer;
			Layout.Windows.Add(LoadLayout());
		}

		private IWindow LoadLayout()
		{
			try
			{
				//IWindow? loadedRoot = _layoutSerializer.DeserializeLayout("Test");

				//if (loadedRoot == null)
				//	return LoadDefaultLayout();

				//return loadedRoot;
			} catch
			{
				//TODO: Add Logging
			}

			return LoadDefaultLayout();
		}

		private IWindow LoadDefaultLayout()
		{
			ITabbedPane assetViewTabbedPane = _componentFactory.CreateTabbedPane();
			ITabbedPane entityViewTabbedPane = _componentFactory.CreateTabbedPane();
			ITabbedPane consoleViewTabbedPane = _componentFactory.CreateTabbedPane();
			ITabbedPane propertyViewTabbedPane = _componentFactory.CreateTabbedPane();

			IComponentPane commandAreaPane = _componentFactory.CreateComponentPane();
			IComponentPane assetViewPane = _componentFactory.CreateComponentPane();
			IComponentPane hierarchyViewPane = _componentFactory.CreateComponentPane();
			IComponentPane entityViewPane = _componentFactory.CreateComponentPane();
			IComponentPane consoleViewPane = _componentFactory.CreateComponentPane();
			IComponentPane propertyViewPane = _componentFactory.CreateComponentPane();

			ISplitPane topMenuSplit = _componentFactory.CreateSplitPane();
			ISplitPane mainSplit = _componentFactory.CreateSplitPane();
			ISplitPane consoleSplit = _componentFactory.CreateSplitPane();

			ILabel commandAreaLabel = _componentFactory.CreateLabelComponent();
			ILabel assetViewLabel = _componentFactory.CreateLabelComponent();
			ILabel hierarchyViewLabel = _componentFactory.CreateLabelComponent();
			ILabel entityViewerLabel = _componentFactory.CreateLabelComponent();
			ILabel consoleViewerLabel = _componentFactory.CreateLabelComponent();
			ILabel entityPropertiesViewerLabel = _componentFactory.CreateLabelComponent();

			commandAreaPane.Title = "Command Area";
			assetViewPane.Title = "Assets";
			hierarchyViewPane.Title = "Hierarchy";
			entityViewPane.Title = "Entity Viewer";
			consoleViewPane.Title = "Console";
			propertyViewPane.Title = "Properties";

			assetViewTabbedPane.AddComponentPane(assetViewPane);
			assetViewTabbedPane.AddComponentPane(hierarchyViewPane);
			entityViewTabbedPane.AddComponentPane(entityViewPane);
			consoleViewTabbedPane.AddComponentPane(consoleViewPane);
			propertyViewTabbedPane.AddComponentPane(propertyViewPane);

			commandAreaLabel.Label = "commandArea";
			assetViewLabel.Label = "assetView";
			hierarchyViewLabel.Label = "hierarchyView";
			entityViewerLabel.Label = "entityViewer";
			consoleViewerLabel.Label = "consoleViewer";
			entityPropertiesViewerLabel.Label = "entityPropertiesViewer";

			commandAreaPane.AddComponent(commandAreaLabel);
			assetViewPane.AddComponent(assetViewLabel);
			hierarchyViewPane.AddComponent(hierarchyViewLabel);
			entityViewPane.AddComponent(entityViewerLabel);
			consoleViewPane.AddComponent(consoleViewerLabel);
			propertyViewPane.AddComponent(entityPropertiesViewerLabel);

			consoleSplit.AddPane(entityViewTabbedPane);
			consoleSplit.AddPane(consoleViewTabbedPane, 200);
			consoleSplit.SplitDirection = SplitDirection.Vertical;

			mainSplit.AddPane(assetViewTabbedPane, 200);
			mainSplit.AddPane(consoleSplit);
			mainSplit.AddPane(propertyViewTabbedPane, 400);

			topMenuSplit.AddPane(commandAreaPane, 100);
			topMenuSplit.AddPane(mainSplit);
			topMenuSplit.SplitDirection = SplitDirection.Vertical;

			IWindow primaryWindow = _componentFactory.CreatePrimaryWindow();

			primaryWindow.Layout = topMenuSplit;

			return primaryWindow;
		}

		public void OnClose()
		{
			_layoutSerializer.SerializeLayout(Layout, "Test");
		}
	}
}
