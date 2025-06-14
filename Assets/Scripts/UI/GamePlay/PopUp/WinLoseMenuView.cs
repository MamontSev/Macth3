using Mathc3.UI.General.PopUp;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Mathc3.UI.GamePlay.PopUp
{
	public class WinLoseMenuView:PopUpBaseAnimator<WinLoseMenuViewModel>, IWinLoseMenuView
	{
		private WinLoseMenuViewModel _model;
		protected override void OnBind( WinLoseMenuViewModel model )
		{
			_model = model;
		}

		protected override void OnHide()
		{
			ReplayButton.onClick.RemoveAllListeners();
		}

		protected override void OnShow()
		{
			ReplayButton.onClick.AddListener(_model.OnReplayPressed);
			_model.OnShowView(this);
		}


		[Header("Header")]
		[SerializeField]
		private TextMeshProUGUI HeaderText;

		public void SetHeaderText( string s )
		{
			HeaderText.text = s;
		}


		[Header("ContinueButton")]
		[SerializeField]
		private Button ReplayButton;

	}
}
