using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class BasicPanel : Panel, IPanelComponent
	{
		protected override Type StyleKeyOverride => typeof(Panel);

		public IComponent? Component {
			get
			{
				if (Children.Count >= 1 && Children[0] is IComponent child)
					return child;
				return null;
			}
			set
			{
				if (value is Control control)
				{
					if (Children.Count == 0)
						Children.Add(control);
					else
						Children[0] = control;
				}
			}
		}
	}
}
