using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI.Components;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates;

public partial class WindowComponent : Window, IWindowComponent
{
	public IPanelComponent Panel { get; set; }

    public WindowComponent()
    {
        InitializeComponent();
    }
}