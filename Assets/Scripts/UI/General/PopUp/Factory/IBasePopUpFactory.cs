using Mathc3.UI.MVVM;

namespace Mathc3.UI.General.PopUp
{
	public interface IBasePopUpFactory
	{
		void Show<T>( T vm ) where T : IPopUpViewModel;
	}
}
