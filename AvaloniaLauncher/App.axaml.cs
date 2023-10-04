using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MochaMothMedia.MochaMaker.AvaloniaUI.Factories;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Factories;
using MochaMothMedia.MochaMaker.Editor;
using MochaMothMedia.MochaMaker.UI.Core;

namespace MochaMothMedia.MochaMaker.AvaloniaLauncher
{
	public partial class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public override void OnFrameworkInitializationCompleted()
		{
			ServiceProvider serviceProvider = new ServiceCollection()
				.AddSingleton<ILabelFactory, LabelFactory>()
				.AddSingleton<IComponentFactory, ComponentFactoryFacade>()
				.AddSingleton<IEditorWindow, EditorWindow>()
				.BuildServiceProvider();

			IEditorWindow editorWindow = serviceProvider.GetService<IEditorWindow>()!;

			MainWindow mainWindow = new MainWindow();
			ContentPresenter presenter = mainWindow.FindControl<ContentPresenter>("content")!;

			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				desktop.MainWindow = mainWindow;
			}

			base.OnFrameworkInitializationCompleted();

			presenter.Content = editorWindow.GetLayout();
		}
	}
}
