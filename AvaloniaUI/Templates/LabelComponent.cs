using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI.Components;
using System.Runtime.Serialization;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class LabelComponent : Label, ILabelComponent
	{
		protected override Type StyleKeyOverride => typeof(Label);

		public string Label { 
			get
			{
				if (Content is string text)
					return text;
				return string.Empty;
			}

			set
			{
				Content = value;
			}
		}
	}
}
