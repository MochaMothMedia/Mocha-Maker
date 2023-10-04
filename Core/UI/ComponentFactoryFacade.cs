using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.Core.UI.Factories;

namespace MochaMothMedia.MochaMaker.Core.UI
{
	public class ComponentFactoryFacade : IComponentFactory
	{
		private readonly ILabelFactory _labelFactory;

		public ComponentFactoryFacade(
			ILabelFactory labelFactory)
		{
			_labelFactory = labelFactory;
		}

		public ILabelComponent CreateLabelComponent() => _labelFactory.CreateComponent();
	}
}
