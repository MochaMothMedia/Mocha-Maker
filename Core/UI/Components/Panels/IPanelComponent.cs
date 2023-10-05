namespace MochaMothMedia.MochaMaker.Core.UI.Components.Panels
{
    public interface IPanelComponent : IComponent
    {
        IComponent? Component { get; set; }
    }
}
