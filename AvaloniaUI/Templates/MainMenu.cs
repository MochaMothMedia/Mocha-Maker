using Avalonia.Controls;
using MochaMothMedia.MochaMaker.Core.Menu;

namespace MochaMothMedia.MochaMaker.AvaloniaUI.Templates
{
	public class MainMenu : DockPanel, IMenu
	{
		private Dictionary<string, MenuItemNode> _menuItemNodes = new Dictionary<string, MenuItemNode>();
		private Menu _menu;

		public MainMenu(IEnumerable<IMenuItem> menuItems)
		{
			foreach (IMenuItem menuItem in menuItems)
			{
				if (menuItem == null)
					continue;

				if (menuItem.Location == null || menuItem.Location.Length == 0)
					continue;

				if (_menuItemNodes.ContainsKey(menuItem.Location[0]))
					_menuItemNodes[menuItem.Location[0]].AddNode(menuItem.Location.ToList(), menuItem);
				else
				{
					MenuItemNode newNode = new MenuItemNode();
					newNode.AddNode(menuItem.Location.ToList().GetRange(1, menuItem.Location.Length - 1), menuItem);
					_menuItemNodes.Add(menuItem.Location[0], newNode);
				}
			}

			List<string> priorityMenuItems = new List<string>()
			{
				DefaultMenuLocations.File,
				DefaultMenuLocations.Edit,
				DefaultMenuLocations.View,
				DefaultMenuLocations.Help
			};

			_menu = new Menu();

			foreach (string priorityMenuItem in priorityMenuItems)
			{
				if (!_menuItemNodes.ContainsKey(priorityMenuItem))
					continue;

				MenuItemNode node = _menuItemNodes[priorityMenuItem];

				_menu.Items.Add(node.CreateMenuItem(priorityMenuItem));
			}

			foreach (KeyValuePair<string, MenuItemNode> nodes in _menuItemNodes)
			{
				if (priorityMenuItems.Contains(nodes.Key))
					continue;

				MenuItemNode node = _menuItemNodes[nodes.Key];
				MenuItem menuItem = new MenuItem() { Header = nodes.Key };

				_menu.Items.Add(node.CreateMenuItem(nodes.Key));
			}

			_menu.SetValue(DockProperty, Dock.Top);
			Children.Add(_menu);
		}

		private class MenuItemNode
		{
			public Dictionary<string, MenuItemNode> Nodes { get; set; } = new Dictionary<string, MenuItemNode>();
			public IMenuItem? MenuItem { get; set; }

			public IMenuItem? GetPath(List<string> path)
			{
				if (Nodes.ContainsKey(path[0]))
				{
					if (path.Count == 1)
						return Nodes[path[0]].MenuItem;

					return Nodes[path[0]].GetPath(path.GetRange(1, path.Count - 1));
				}

				return null;
			}

			public void AddNode(List<string> path, IMenuItem node)
			{
				if (GetPath(path) != null)
					return;

				if (Nodes.ContainsKey(path[0]))
					Nodes[path[0]].AddNode(path.GetRange(1, path.Count - 1), node);

				else if (path.Count == 1)
					Nodes.Add(path[0], new MenuItemNode() { MenuItem = node });

				else
				{
					Nodes.Add(path[0], new MenuItemNode());
					Nodes[path[0]].AddNode(path.GetRange(1, path.Count - 1), node);
				}
			}

			public MenuItem CreateMenuItem(string header)
			{
				MenuItem menuItem = new MenuItem() { Header = header };

				if (MenuItem == null)
				{
					foreach (KeyValuePair<string, MenuItemNode> node in Nodes)
					{
						menuItem.Items.Add(node.Value.CreateMenuItem(node.Key));
					}
				}
				else
				{
					menuItem.Click += (sender, e) => MenuItem.Execute();
				}

				return menuItem;
			}
		}
	}
}
