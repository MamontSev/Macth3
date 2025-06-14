using System;
using System.Collections;

using Mathc3.UI.MVVM;

using UnityEngine;

namespace Mathc3.UI.General.PopUp
{
	[RequireComponent(typeof(Animator))]
	public abstract class PopUpBaseAnimator<T>:BasePopUpView<T> where T : IPopUpViewModel
	{
		private bool? _isShow = null;
		public override sealed void Hide()
		{
			if( _isShow == false )
			{
				return;
			}
			OnHide();
			_isShow = false;
			_animator.SetInteger(AnimParName , (int)AnimType.Hide);

			OnCloze?.Invoke(this);

			StartCoroutine(delay());
			IEnumerator delay()
			{
				yield return new WaitForSecondsRealtime(0.25f);
				Destroy(gameObject);
			}
		}

		private Action<IPopUpView> OnCloze;
		public override sealed void Show( Action<IPopUpView> OnCloze )
		{
			if( _isShow == true )
			{
				return;
			}
			this.OnCloze = OnCloze;
			OnShow();
			_isShow = true;
			_animator.SetInteger(AnimParName , (int)AnimType.Show);
		}



		protected abstract void OnHide();
		protected abstract void OnShow();


		private Animator _animator => GetComponent<Animator>();
		private const string AnimParName = "intPar";
		private enum AnimType
		{
			Show = 0,
			Hide = 1
		}

	}
}
