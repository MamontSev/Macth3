using UnityEngine;

namespace Mathc3.UI.MVVM
{
	public abstract class BaseShowHideView<T>:MonoBehaviour, IShowHideView where T : IViewModel
	{
		public abstract void Hide();
		public abstract void Show();


		public void Bind<Tmodel>( Tmodel model ) where Tmodel :  IViewModel 
		{
			if( model is T t )
			{
			   OnBind(t);	 
			}
		}

		protected abstract void OnBind( T model );
		protected abstract void OnHide();
		protected abstract void OnShow();

	}
}
