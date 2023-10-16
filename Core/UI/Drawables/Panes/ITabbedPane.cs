namespace MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes
{
	public interface ITabbedPane : IPane
	{
		int ActivePane { get; set; }
		IComponentPane[] Panes { get; set; }

		void AddComponentPane(IComponentPane pane);
		void AddComponentPaneAt(int index, IComponentPane pane);
		void RemoveComponentPaneAt(int index);
	}
}
