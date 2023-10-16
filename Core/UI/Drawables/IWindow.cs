namespace MochaMothMedia.MochaMaker.Core.UI.Drawables
{
	public interface IWindow
	{
		IDrawable GetRoot();
		void OnClose();
	}
}
