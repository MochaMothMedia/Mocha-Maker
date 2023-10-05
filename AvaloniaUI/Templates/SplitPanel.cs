using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class SplitPanel : Grid, ISplitPanelComponent
	{
		protected override Type StyleKeyOverride => typeof(Grid);
		SplitDirection _splitDirection;

		public SplitPanel()
		{
			SplitDirection = SplitDirection.Horizontal;
		}

		public SplitDirection SplitDirection
		{
			get => _splitDirection;
			set
			{
				_splitDirection = value;

				RecalculateDefinitions();
			}
		}

		public void AddComponentAt(int index, IComponent component)
		{
			int actualIndex = (index * 2) - 1;
			int clampedIndex = Math.Clamp(actualIndex, 0, Children.Count);

			if (component is Control control)
			{
				if (Children.Count == 0)
				{
					Children.Add(control);
					RecalculateDefinitions();
					return;
				}

				if (clampedIndex == 0)
				{
					Children.Insert(0, new GridSplitter());
					Children.Insert(0, control);
					RecalculateDefinitions();
					return;
				}

				if (clampedIndex == Children.Count)
				{
					Children.Add(new GridSplitter());
					Children.Add(control);
					RecalculateDefinitions();
					return;
				}

				Children.Insert(clampedIndex, control);
				Children.Insert(clampedIndex, new GridSplitter());
				RecalculateDefinitions();
			}
		}

		public void RemoveComponentAt(int index)
		{
			int actualIndex = (index * 2) - 1;
			int clampedIndex = Math.Clamp(actualIndex, 0, Children.Count);
		}

		void RecalculateDefinitions()
		{
			string definition = string.Join(", ", Children.Select(child => child is GridSplitter ? "2" : "*"));

			switch (_splitDirection)
			{
				case SplitDirection.Horizontal:
					ColumnDefinitions = new ColumnDefinitions(definition);
					RowDefinitions = new RowDefinitions("*");

					for (int i = 0; i < Children.Count; i++)
					{
						if (Children[i] is GridSplitter splitter)
							splitter.ResizeDirection = GridResizeDirection.Columns;

						if (Children[i] is Control control)
						{
							control.SetValue(ColumnProperty, i);
							control.SetValue(RowProperty, 0);
						}
					}
					break;

				case SplitDirection.Vertical:
					ColumnDefinitions = new ColumnDefinitions("*");
					RowDefinitions = new RowDefinitions(definition);

					for (int i = 0; i < Children.Count; i++)
					{
						if (Children[i] is GridSplitter splitter)
							splitter.ResizeDirection = GridResizeDirection.Rows;

						if (Children[i] is Control control)
						{
							control.SetValue(ColumnProperty, 0);
							control.SetValue(RowProperty, i);
						}
					}
					break;
			}
		}
	}
}
