using MochaMothMedia.MochaMaker.AvaloniaUI.Templates;
using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.Core.UI.Factories;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Factories
{
	public class LabelFactory : ILabelFactory
	{
		public ILabelComponent CreateComponent()
		{
			LabelComponent label = new LabelComponent();

			return label;
		}
	}
}
