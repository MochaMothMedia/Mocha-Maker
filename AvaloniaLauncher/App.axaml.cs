using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MochaMothMedia.MochaMaker.AvaloniaUI.Factories;
using MochaMothMedia.MochaMaker.Core;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Panes;
using MochaMothMedia.MochaMaker.Editor;
using MochaMothMedia.MochaMaker.YAMLSerializer;
using MochaMothMedia.MochaMaker.Serialization;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;
using MochaMothMedia.MochaMaker.Core.UI.Factories;
using MochaMothMedia.MochaMaker.Core.Menu;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Windows;
using MochaMothMedia.MochaMaker.AvaloniaUI.Templates;
using MochaMothMedia.MochaMaker.MenuItems.Layout;
using MochaMothMedia.MochaMaker.Core.UI.Drawables;
using MochaMothMedia.MochaMaker.AvaloniaUI.Templates.Panes;
using Avalonia.Layout;

namespace MochaMothMedia.MochaMaker.AvaloniaLauncher
{
    public partial class App : Application
	{
		IEditorWindow? _editorWindow;

		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public override void OnFrameworkInitializationCompleted()
		{
			ServiceProvider serviceProvider = new ServiceCollection()
				// Component Factories
				.AddSingleton<ILabelFactory, LabelFactory>()
				.AddSingleton<IComponentPaneFactory, ComponentPaneFactory>()
				.AddSingleton<ISplitPaneFactory, SplitPaneFactory>()
				.AddSingleton<ITabbedPaneFactory, TabbedPaneFactory>()

				.AddSingleton<IPopupWindowFactory, PopupWindowFactory>()
				.AddSingleton<IConfirmationWindowFactory, ConfirmationWindowFactory>()
				.AddSingleton<IPrimaryWindowFactory, PrimaryWindowFactory>()

				// Factory Facade
				.AddSingleton<IComponentFactory, ComponentFactoryFacade>()

				// Menu
				.AddSingleton<IMenuItem, SaveLayoutMenuItem>()
				.AddSingleton<IMenu, MainMenu>()

				// Serialization
				.AddSingleton<ISerializationTools, SerializationTools>()
				.AddSingleton<ILayoutSerializer, LayoutSerializer>()

				// Windows
				.AddSingleton<IEditorWindow, EditorWindow>()

				.BuildServiceProvider();

			_editorWindow = serviceProvider.GetService<IEditorWindow>()!;
			MainMenu mainMenu = (serviceProvider.GetService<IMenu>()! as MainMenu)!;

			MainWindow mainWindow = new MainWindow();
			mainWindow.Closing += OnClose;
			ContentPresenter presenter = mainWindow.FindControl<ContentPresenter>("content")!;
			DockPanel dockPanel = new DockPanel()
			{
				VerticalAlignment = VerticalAlignment.Stretch
			};

			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				desktop.MainWindow = mainWindow;
			}

			base.OnFrameworkInitializationCompleted();

			IWindow[] layout = _editorWindow.Layout.Windows.ToArray();
			Control mainLayout = (layout[0].Layout as Control)!;

			mainMenu.SetValue(DockPanel.DockProperty, Dock.Top);
			mainLayout.SetValue(DockPanel.DockProperty, Dock.Bottom);

			dockPanel.Children.Add(mainMenu);
			dockPanel.Children.Add(mainLayout);

			presenter.Content = dockPanel;

			for (int i = 1; i < layout.Length; i++)
			{
				//TODO: Draw additional windows
			}
		}

		public void OnClose(object? sender, WindowClosingEventArgs eventArgs)
		{
			if (_editorWindow == null)
				return;

			foreach (IWindow window in _editorWindow.Layout.Windows)
			{
				window?.OnClose();
			}

			_editorWindow.OnClose();
		}
	}
}
