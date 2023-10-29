using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;
using Avalonia.Interactivity;
using Avalonia.Platform;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class ConfirmationWindow : Window, IConfirmationWindow
	{
		private Label _messageLabel;
		private Button _acceptButton;
		private Button _denyButton;

		public string Message { set => _messageLabel.Content = value; }
		public string YesText { set => _acceptButton.Content = value; }
		public string NoText { set => _denyButton.Content = value; }

		public ConfirmationWindow()
		{
			_messageLabel = new Label();
			_acceptButton = new Button();
			_denyButton = new Button();

			Cursor pointer = new Cursor(StandardCursorType.Hand);
			_acceptButton.Cursor = pointer;
			_denyButton.Cursor = pointer;

			StackPanel mainPanel = new StackPanel() { Orientation = Orientation.Vertical };
			StackPanel buttonPanel = new StackPanel() { Orientation = Orientation.Horizontal };

			buttonPanel.Children.Add(_denyButton);
			buttonPanel.Children.Add(_acceptButton);

			mainPanel.Children.Add(_messageLabel);
			mainPanel.Children.Add(buttonPanel);

			ContentPresenter presenter = new ContentPresenter();

			presenter.Content = mainPanel;

			Content = presenter;

			Width = 300;
			Height = 100;
			CanResize = false;

			Screen? screen = Screens?.Primary;

			if (screen == null)
				return;

			Position = new Avalonia.PixelPoint((int)(screen.WorkingArea.Width - Width) / 2, (int)(screen.WorkingArea.Height - Height) / 2);
		}

		public void AddAcceptListener(Action action)
		{
			_acceptButton.Click += (object? sender, RoutedEventArgs eventArgs) => action?.Invoke();
		}

		public void AddDenyListener(Action action)
		{
			_denyButton.Click += (object? sender, RoutedEventArgs eventArgs) => action?.Invoke();
		}
	}
}
