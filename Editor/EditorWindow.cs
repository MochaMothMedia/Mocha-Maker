using MochaMothMedia.MochaMaker.Core.UI;
using MochaMothMedia.MochaMaker.Core.UI.Components;
using MochaMothMedia.MochaMaker.UI.Core;

namespace MochaMothMedia.MochaMaker.Editor
{
	public class EditorWindow : IEditorWindow
	{
		readonly ILabelComponent _helloWorldLabel;

		public EditorWindow(IComponentFactory componentFactory)
		{
			_helloWorldLabel = componentFactory.CreateLabelComponent();
			_helloWorldLabel.Label = "Hello World!";
		}

		public object? GetLayout()
		{
			return _helloWorldLabel;
		}
	}
}
