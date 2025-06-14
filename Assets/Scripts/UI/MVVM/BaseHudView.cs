using UnityEngine;

namespace Mathc3.UI.MVVM
{
	public abstract class BaseHudView<T> :MonoBehaviour, IView where T:IViewModel
	{
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
