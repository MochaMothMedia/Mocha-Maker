using Avalonia;
using System;

namespace MochaMothMedia.MochaMaker.AvaloniaLauncher
{
	internal class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			_ = BuildAvaloniaApp()
				.StartWithClassicDesktopLifetime(args);
		}

		public static AppBuilder BuildAvaloniaApp()
		{
			return AppBuilder.Configure<App>()
				.UsePlatformDetect()
				.WithInterFont()
				.LogToTrace();
		}
	}
}
