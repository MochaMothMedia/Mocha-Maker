namespace MochaMothMedia.MochaMaker.Core.UI.Components.Panels
{
    public interface ISplitPanelComponent : IComponent
    {
        SplitDirection SplitDirection { get; set; }
        IComponent[] Components { get; set; }
        List<int> SplitSizes { get; set; }

		void AddComponent(IComponent component, int size = 0);
		void AddComponentAt(int index, IComponent component, int size = 0);
        void RemoveComponentAt(int index);
    }
}
