using MochaMothMedia.MochaMaker.Core.UI;

namespace MochaMothMedia.MochaMaker.UI.Core
{
	public interface IEditorWindow : IComponent
	{
		IComponent GetRoot();
	}
}
