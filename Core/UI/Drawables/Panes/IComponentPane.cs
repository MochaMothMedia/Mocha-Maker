namespace MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes
{
	public interface IComponentPane : IPane
	{
		string Title { get; set; }
		IComponent[] Components { get; set; }

		void AddComponent(IComponent component);
		void AddComponentAt(int index, IComponent component);
		void RemoveComponentAt(int index);
	}
}
