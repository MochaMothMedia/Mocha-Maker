namespace MochaMothMedia.MochaMaker.Core.Menu
{
	public interface IMenuItem
	{
		string[] Location { get; }

		void Execute();
	}
}
