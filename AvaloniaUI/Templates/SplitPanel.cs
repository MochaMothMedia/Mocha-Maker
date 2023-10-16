using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Components.Panels;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class SplitPanel : Grid, ISplitPanelComponent
	{
		SplitDirection _splitDirection;
		List<int> _splitSizes = new List<int>();

		protected override Type StyleKeyOverride => typeof(Grid);

		public SplitPanel()
		{
			SplitDirection = SplitDirection.Horizontal;
		}

		public IComponent[] Components
		{
			get
			{
				return Children.Where(child => child as IComponent is not null).Select(child => (child as IComponent)!).ToArray();
			}

			set
			{
				foreach (IComponent child in value)
					AddComponent(child);
			}
		}

		public List<int> SplitSizes {
			get
			{
				if (SplitDirection == SplitDirection.Horizontal)
				{
					return ColumnDefinitions.Select(definition => definition.Width.GridUnitType == GridUnitType.Star ? 0 : (int)definition.Width.Value).Where((definition, index) => index % 2 == 0).ToList();
				}

				return RowDefinitions.Select(definition => definition.Height.GridUnitType == GridUnitType.Star ? 0 : (int)definition.Height.Value).Where((definition, index) => index % 2 == 0).ToList();
			}
			set
			{
				_splitSizes = value;
				RecalculateDefinitions();
			}
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

		public void AddComponent(IComponent component, int size = 0)
		{
			AddComponentAt(Children.Count, component, size);
		}

		public void AddComponentAt(int index, IComponent component, int size = 0)
		{
			int actualIndex = (index * 2) - 1;
			int clampedIndex = Math.Clamp(actualIndex, 0, Children.Count);
			int sizeIndex = Math.Clamp(index, 0, _splitSizes.Count);
			_splitSizes.Insert(sizeIndex, size);

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
			int sizeIndex = Math.Clamp(index, 0, _splitSizes.Count);
			_splitSizes.RemoveAt(sizeIndex);

			Children.RemoveAt(clampedIndex);
			clampedIndex = Math.Clamp(actualIndex, 0, Children.Count);
			Children.RemoveAt(clampedIndex);

			RecalculateDefinitions();
		}

		void RecalculateDefinitions()
		{
			string definition = string.Join(", ", Children.Select((child, index) => child is GridSplitter ? "2" : child is IComponent ? _splitSizes[(index + 1) / 2] == 0 ? "*" : _splitSizes[(index + 1) / 2].ToString() : "*"));

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
