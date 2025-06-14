namespace Mathc3.UI.MVVM
{
	public interface IView
	{
		void Bind<Tmodel>( Tmodel model ) where Tmodel : IViewModel;	   
	}
}
