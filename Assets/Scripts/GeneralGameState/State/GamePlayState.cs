using Manmont.Tools.StateMashine;

using Mathc3.Events;
using Mathc3.SceneControl;
using Mathc3.UI.General.Loading;

namespace Mathc3.GeneralStateMashine
{
	public class GamePlayState:IGeneralGameState, IEnterState 
	{
		private readonly ILoadingPanel _loadingPanel;
		private readonly ISceneControlService _sceneControlService;
		private readonly IEventBusService _eventBusService;
		public GamePlayState
		(
			ILoadingPanel _loadingPanel ,
			ISceneControlService _sceneControlService,
			IEventBusService _eventBusService
		)
		{
			this._loadingPanel = _loadingPanel;
			this._sceneControlService = _sceneControlService;
			this._eventBusService = _eventBusService;
		}

		public void Enter()
		{
			_loadingPanel.Show();
			_sceneControlService.LoadScene("GamePlay");
		}

	}

}

