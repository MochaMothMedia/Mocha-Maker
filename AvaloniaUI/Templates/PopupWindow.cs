using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Controls.Presenters;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Windows;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class PopupWindow : Window, IPopupWindow
	{
		Action _onSubmit = () => { };
		Action _onCancel = () => { };

		event EventHandler OnSubmit = delegate { };
		event EventHandler OnCancel = delegate { };

		StackPanel _fieldPanel;

		public PopupWindow()
		{
			ContentPresenter presenter = new ContentPresenter();
			StackPanel mainPanel = new StackPanel() { Orientation = Orientation.Vertical };

			_fieldPanel = new StackPanel() { Orientation = Orientation.Vertical };

			StackPanel buttonPanel = CreateButtonPanel();

			mainPanel.Children.Add(_fieldPanel);
			mainPanel.Children.Add(buttonPanel);

			presenter.Content = mainPanel;

			Content = presenter;

			Width = 400;
			Height = 100;
			CanResize = false;

			Screen? screen = Screens?.Primary;

			if (screen == null)
				return;

			Position = new Avalonia.PixelPoint((int)(screen.WorkingArea.Width - Width) / 2, (int)(screen.WorkingArea.Height - Height) / 2);
		}

		public void AddField<T>(string label, Action<T> onChange, T defaultValue)
		{
			StackPanel panel = new StackPanel() { Orientation = Orientation.Horizontal };

			Label fieldLabel = new Label();
			fieldLabel.Content = label;
			panel.Children.Add(fieldLabel);

			if (typeof(T) == typeof(string))
			{
				TextBox textBox = new TextBox();
				textBox.Text = defaultValue as string;
				textBox.TextChanged += (object? sender, TextChangedEventArgs eventArgs) =>
				{
					if (textBox.Text is T value)
						onChange(value);
				};
				panel.Children.Add(textBox);
			}

			_fieldPanel.Children.Add(panel);
		}

		private StackPanel CreateButtonPanel()
		{
			StackPanel buttonPanel = new StackPanel() { Orientation = Orientation.Horizontal, Spacing = 2 };

			Button submitButton = new Button() { Content = "Submit" };
			Button cancelButton = new Button() { Content = "Cancel" };

			submitButton.Click += (object? sender, RoutedEventArgs eventArgs) => OnSubmit?.Invoke(sender, eventArgs);
			cancelButton.Click += (object? sender, RoutedEventArgs eventArgs) => OnCancel?.Invoke(sender, eventArgs);

			Cursor pointer = new Cursor(StandardCursorType.Hand);
			submitButton.Cursor = pointer;
			cancelButton.Cursor = pointer;

			buttonPanel.Children.Add(cancelButton);
			buttonPanel.Children.Add(submitButton);

			return buttonPanel;
		}

		public void AddSubmitListener(Action onSubmit) => OnSubmit += (object? sender, EventArgs eventArgs) => onSubmit();
		public void AddCancelListener(Action onCancel) => OnCancel += (object? sender, EventArgs eventArgs) => onCancel();
		public void OnClose() => OnCancel?.Invoke(this, new EventArgs());
	}
}
