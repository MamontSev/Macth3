using UnityEngine;

namespace Mathc3.UI.General.Loading
{
	public interface ILoadingPanel
	{
		void Hide();
		void Show();
	}
	public class LoadingPanel:MonoBehaviour, ILoadingPanel
	{
		private bool _isShow = false;
		public void Show()
		{
			if( _isShow == true )
				return;
			_isShow = true;
			_inCont.SetActive(true);
		}
		public void Hide()
		{
			if( _isShow == false )
				return;
			_isShow = false;
			_inCont.SetActive(false);
		}
		[SerializeField]
		private GameObject _inCont;

	}
}

