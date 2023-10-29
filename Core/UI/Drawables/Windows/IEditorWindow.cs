namespace MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows
{
    public interface IEditorWindow
    {
        WindowSet Layout { get; set; }

        public void OnClose();
    }
}
