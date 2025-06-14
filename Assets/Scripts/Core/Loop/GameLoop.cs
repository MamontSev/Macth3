namespace Mathc3.Core.Loop
{

	public class GameLoop:IGameLoop
	{
        public GameLoop()
        {
			_state = State.Await;
		}
        private State _state = State.Await;
		public bool IsPlayMode => _state == State.Play;

		public void StartGame()
		{
			_state = State.Play;
		}
		public void AwaitGame()
		{
			_state = State.Await;
		}
	
		enum State
		{
			Await = 0,
			Play = 1
		}
	}
}
