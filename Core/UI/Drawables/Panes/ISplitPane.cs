namespace MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes
{
    public interface ISplitPane : IPane
    {
        SplitDirection SplitDirection { get; set; }
        List<int> SplitSizes { get; set; }
		IPane[] Panes { get; set; }

		void AddPane(IPane pane, int size = 0);
		void AddPaneAt(int index, IPane pane, int size = 0);
        void RemovePaneAt(int index);
    }
}
