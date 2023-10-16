using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates.Components
{
    public class LabelComponent : Label, ILabel
    {
        protected override Type StyleKeyOverride => typeof(Label);

        public string Label
        {
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
