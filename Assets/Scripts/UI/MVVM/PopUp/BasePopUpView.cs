using System;

using UnityEngine;

namespace Mathc3.UI.MVVM
{
	public abstract class BasePopUpView<T>:MonoBehaviour, IPopUpView where T : IViewModel
	{
		public abstract void Hide();
		public abstract void Show( Action<IPopUpView> OnCloze );

		public void Bind( object model )
		{
			if( model is T t )
			{
				Bind(t);
			}
		}

		public void Bind<Tmodel>( Tmodel model ) where Tmodel : IViewModel
		{
			if( model is T t )
			{
				OnBind(t);
			}
		}

		protected abstract void OnBind( T model );
	}
}
