using MochaMothMedia.MochaMaker.Core.Menu;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;

namespace MochaMothMedia.MochaMaker.MenuItems.Layout
{
	public class SaveLayoutMenuItem : IMenuItem
	{
		public string[] Location => new string[]
		{
			"Layout",
			"Save Layout"
		};

		private IPopupWindow? _popupPane;

		private string _layoutName = "New Layout";
		private readonly IComponentFactory _componentFactory;
		private readonly ILayoutSerializer _layoutSerializer;
		private readonly IEditorWindow _editorWindow;

		public SaveLayoutMenuItem(IComponentFactory componentFactory, ILayoutSerializer layoutSerializer, IEditorWindow editorWindow)
		{
			_componentFactory = componentFactory;
			_layoutSerializer = layoutSerializer;
			_editorWindow = editorWindow;
		}

		public void Execute()
		{
			if (_popupPane == null)
				_popupPane = _componentFactory.CreatePopupWindow();

			_popupPane.AddField("Layout Name", name => _layoutName = name, _layoutName);
			_popupPane.AddSubmitListener(Submit);
			_popupPane.AddCancelListener(Cancel);

			_popupPane.Show();
		}

		private void Submit()
		{
			IConfirmationWindow confirmationWindow = _componentFactory.CreateConfirmationWindow();

			confirmationWindow.Title = "Confirmation";
			confirmationWindow.Message = "Are you sure?";
			confirmationWindow.YesText = "Yes";
			confirmationWindow.NoText = "No";

			confirmationWindow.AddAcceptListener(() =>
			{
				confirmationWindow.Close();
				_layoutSerializer.SerializeLayout(_editorWindow.Layout, _layoutName);
				_popupPane?.Close();
				_popupPane = null;
			});

			confirmationWindow.AddDenyListener(() =>
			{
				confirmationWindow.Close();
			});

			confirmationWindow.Show();
		}

		private void Cancel()
		{
			_popupPane?.Close();
			_popupPane = null;
		}
	}
}
