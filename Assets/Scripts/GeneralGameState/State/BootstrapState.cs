using Manmont.Tools.StateMashine;

using Mathc3.Data.GameItem.Content;
using Mathc3.Data.GameItem.Frame;
using Mathc3.Data.GameItem.Shape;
using Mathc3.UI.General.Loading;

namespace Mathc3.GeneralStateMashine
{
	public class BootstrapState:IGeneralGameState, IEnterState
	{
		private readonly ILoadingPanel _loadingPanel;
		private readonly ShapeConfig _shapeConfig;
		private readonly FrameConfig _frameConfig;
		private readonly ContentConfig _contentConfig;
		private readonly GeneralGameStateMachine _generalGameStateMachine;

		public BootstrapState
		(
			ILoadingPanel _loadingPanel ,
			ShapeConfig _shapeConfig,
			FrameConfig _frameConfig,
			ContentConfig _contentConfig,
			GeneralGameStateMachine _generalGameStateMachine
		)
		{
			this._loadingPanel = _loadingPanel;
			this._shapeConfig = _shapeConfig;
			this._frameConfig = _frameConfig;
			this._contentConfig = _contentConfig;
			this._generalGameStateMachine = _generalGameStateMachine;
		}

		public void Enter()
		{
			_loadingPanel.Show();

			ValidateData();
			_generalGameStateMachine.Enter<GamePlayState>();
		}

		private void ValidateData()
		{
			_shapeConfig.Validate();
			_frameConfig.Validate();
			_contentConfig.Validate();
		}
	}

}

