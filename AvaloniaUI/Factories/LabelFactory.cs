using MochaMothMedia.MochaMaker.AvaloniaUI.Templates.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;
using MochaMothMedia.MochaMaker.Core.UI.Factories.Components;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
    public class LabelFactory : ILabelFactory
	{
		public ILabel Create()
		{
			LabelComponent label = new LabelComponent();

			return label;
		}
	}
}
