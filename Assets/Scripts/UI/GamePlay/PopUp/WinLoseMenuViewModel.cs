using Mathc3.Core.Field.Control;
using Mathc3.UI.MVVM;

using Zenject;

namespace Mathc3.UI.GamePlay.PopUp
{
	public class WinLoseMenuViewModel:IPopUpViewModel
	{
		private readonly string _message;
		public WinLoseMenuViewModel( string _message )
		{
			this._message = _message;

		}
		private IFieldControl _fieldControl;
		[Inject]
		private void Construct
		(
			IFieldControl _fieldControl
		)
		{
			this._fieldControl = _fieldControl;
		}

		private IWinLoseMenuView _myView;
		public void OnShowView( IWinLoseMenuView _myView )
		{
			this._myView = _myView;
			_myView.SetHeaderText(_message);
		}

		public void OnReplayPressed()
		{
			_myView.Hide();
			_fieldControl.ReplayOnWinOrLose();
		}
	}
}
