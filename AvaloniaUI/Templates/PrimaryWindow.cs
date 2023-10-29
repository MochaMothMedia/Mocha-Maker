using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Drawables;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class PrimaryWindow : Window, IWindow
	{
		public IDrawable? Layout { get; set; }

		public PrimaryWindow() { }

		public void OnClose()
		{
			//
		}
	}
}
