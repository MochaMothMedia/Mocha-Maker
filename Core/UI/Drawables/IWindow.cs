namespace MochaMothMedia.MochaMaker.Core.UI.Drawables
{
	public interface IWindow
	{
		public IDrawable? Layout { get; set; }

		void OnClose();
	}
}
