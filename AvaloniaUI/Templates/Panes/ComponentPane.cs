using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI.Drawables;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates.Panes
{
    public class ComponentPane : Panel, IComponentPane
    {
        protected override Type StyleKeyOverride => typeof(Panel);

        public string Title { get; set; } = "";
        public IComponent[] Components
        {
            get
            {
                return Children.Where(child => child as IComponent is not null).Select(child => (child as IComponent)!).ToArray();
            }

            set
            {
                foreach (IComponent child in value)
                    AddComponent(child);
            }
        }

        public void AddComponent(IComponent component) => AddComponentAt(Components.Length, component);

        public void AddComponentAt(int index, IComponent component)
        {
            int clampedIndex = Math.Clamp(index, 0, Children.Count);

            if (component is Control control)
            {
                Children.Insert(clampedIndex, control);
            }
        }

        public void RemoveComponentAt(int index)
        {
            int clampedIndex = Math.Clamp(index, 0, Children.Count - 1);

            Children.RemoveAt(clampedIndex);
        }
    }
}
