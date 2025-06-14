using System;

namespace Mathc3.UI.MVVM
{
	public interface IPopUpView:IView
	{
		void Hide();
		void Show(Action<IPopUpView> OnCloze);
	}
}
