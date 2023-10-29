namespace MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows
{
	public interface IPopupWindow
	{
		void AddField<T>(string label, Action<T> onChange, T defaultValue);
		void AddSubmitListener(Action onSubmit);
		void AddCancelListener(Action onCancel);
		void Show();
		void Close();
	}
}
