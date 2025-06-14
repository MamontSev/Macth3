using Mathc3.Log;
using Mathc3.UI.General.PopUp;

using UnityEngine;

using Zenject;

namespace Mathc3.UI.GamePlay.PopUp
{
	public class GamePlayPopUpFactory:BasePopUpFactory
	{
		[Inject]
		private void Construct(
			ILogService _logService ,
			DiContainer _diContainer 
		)
		{
			this._logService = _logService;
			this._diContainer = _diContainer;
		}

		protected sealed override void InitPrefabs()
		{
			_prefabDict.Add(typeof(WinLoseMenuViewModel) , _winLoseMenuView.gameObject);
		}

		[SerializeField]
		private WinLoseMenuView _winLoseMenuView;

	}
}
