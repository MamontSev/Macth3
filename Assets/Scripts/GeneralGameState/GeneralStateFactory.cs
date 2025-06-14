using Manmont.Tools.StateMashine;

using Zenject;


namespace Mathc3.GeneralStateMashine
{
	public class GeneralStateFactory
	{
		private readonly DiContainer _diContainer;
		public GeneralStateFactory( DiContainer _diContainer )
		{
			this._diContainer = _diContainer;
		}

		public T Create<T>() where T: IGeneralGameState
		{
			return _diContainer.Instantiate<T>();
		}
	}
}
