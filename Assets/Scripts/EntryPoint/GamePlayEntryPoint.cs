using Mathc3.Core.Field.Control;
using Mathc3.Core.Loop;
using Mathc3.UI.General.Loading;

using UnityEngine;

using Zenject;

namespace Mathc3.EntryPoint
{
	public class GamePlayEntryPoint:MonoBehaviour
	{
		private ILoadingPanel _loadingPanel;
		private IFieldControl _fieldControl;
		[Inject]
		private void Construct
		(
			ILoadingPanel _loadingPanel ,
			IFieldControl _fieldControl
		)
		{
			this._loadingPanel = _loadingPanel;
			this._fieldControl = _fieldControl;
		}
		private void Start()
		{
			_loadingPanel.Hide();

			_fieldControl.InitOnStart();
		}
	}
}



