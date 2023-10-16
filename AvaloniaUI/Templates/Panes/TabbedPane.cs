using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Components;
using MochaMothMedia.MochaMaker.Core.UI.Drawables.Panes;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates.Panes
{
	internal class TabbedPane : StackPanel, ITabbedPane
	{
		private StackPanel _tabPanel;
		private Panel _contentPanel;
		private List<IComponentPane> _panes = new List<IComponentPane>();
		private int _activePane = 0;

		public IComponentPane[] Panes {
			get
			{
				return _panes.ToArray();
			}

			set
			{
				_panes = new List<IComponentPane>();

				foreach (IComponentPane pane in value)
					AddComponentPane(pane);
			}
		}

		public int ActivePane
		{
			get
			{
				return _activePane;
			}

			set
			{
				_activePane = Math.Clamp(value, 0, Math.Max(0, _panes.Count - 1));
				UpdatePane();
			}
		}

		public TabbedPane()
		{
			_tabPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal
			};
			_contentPanel = new Panel();

			_tabPanel.Height = 22;

			Panel spacer = new Panel();
			spacer.Height = 1;
			Style testStyle = new Style(x => x.OfType<GridSplitter>());
			spacer.Background = Brushes.DimGray;

			Children.Add(_tabPanel);
			Children.Add(spacer);
			Children.Add(_contentPanel);
		}

		public void AddComponentPane(IComponentPane pane) => AddComponentPaneAt(_panes.Count, pane);

		public void AddComponentPaneAt(int index, IComponentPane pane)
		{
			int clampedIndex = Math.Clamp(index, 0, _panes.Count);
			_panes.Insert(clampedIndex, pane);
			Control tab = CreateTab(pane);
			_tabPanel.Children.Insert(clampedIndex, tab);
			_activePane = clampedIndex;

			tab.PointerPressed += (object sender, PointerPressedEventArgs eventArgs) =>
			{
				if (clampedIndex == _activePane)
					return;

				_activePane = clampedIndex;
				UpdatePane();
			};

			UpdatePane();
		}

		public void RemoveComponentPaneAt(int index)
		{
			int clampedIndex = Math.Clamp(index, 0, _panes.Count - 1);
			_panes.RemoveAt(clampedIndex);
			_tabPanel.Children.RemoveAt(clampedIndex);
			UpdatePane();
		}

		private void UpdatePane()
		{
			if (_panes.Count == 0)
				return;

			_contentPanel.Children.Clear();
			_contentPanel.Children.Add((Control)_panes[_activePane]);

			for (int i = 0; i < _panes.Count; i++)
			{
				if (i == _activePane)
					((Panel)_tabPanel.Children[i]).Background = Brushes.DimGray;
				else
					((Panel)_tabPanel.Children[i]).Background = new SolidColorBrush(Color.FromArgb(255, 75, 75, 75));
			}
		}

		private Control CreateTab(IComponentPane pane)
		{
			Label header = new Label
			{
				Content = pane.Title
			};

			Panel headerPanel = new Panel
			{
				Margin = new Avalonia.Thickness(2, 2, 2, 0),
				Background = Brushes.DarkSlateGray,
				Cursor = new Cursor(StandardCursorType.Hand)
			};

			headerPanel.Children.Add(header);

			return headerPanel;
		}
	}
}
