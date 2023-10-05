namespace MochaMothMedia.MochaMaker.Core.UI.Components.Panels
{
    public interface ISplitPanelComponent : IComponent
    {
        SplitDirection SplitDirection { get; set; }

        void AddComponentAt(int index, IComponent component);
        void RemoveComponentAt(int index);
    }
}
