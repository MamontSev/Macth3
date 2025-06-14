namespace Mathc3.Core.Loop
{
	public interface IGameLoop
	{
		bool IsPlayMode
		{
			get;
		}

		void AwaitGame();
		void StartGame();
	}
}