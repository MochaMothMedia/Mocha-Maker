using MochaMothMedia.MochaMaker.Core.UI;

namespace MochaMothMedia.MochaMaker.UI.Core
{
	public interface IEditorWindow
	{
		IComponent GetRoot();
		void OnClose();
	}
}
