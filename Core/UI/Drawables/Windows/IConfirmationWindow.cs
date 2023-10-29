namespace MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows
{
	public interface IConfirmationWindow
	{
		string Title { set; }
		string Message { set; }
		string YesText { set; }
		string NoText { set; }

		void AddAcceptListener(Action action);
		void AddDenyListener(Action action);

		void Show();
		void Close();
	}
}
