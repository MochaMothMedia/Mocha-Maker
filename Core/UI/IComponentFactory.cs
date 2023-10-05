using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;

namespace MochaMothMedia.MochaMaker.Core.UI
{
    public interface IComponentFactory
	{
		ILabelComponent CreateLabelComponent();
		IPanelComponent CreateBasicPanelComponent();
		ISplitPanelComponent CreateSplitPanelComponent();
	}
}
