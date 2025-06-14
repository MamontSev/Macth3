using Mathc3.Core.InputControl;
using Mathc3.Core.Item;

namespace Mathc3.Events.Signals
{
	public class PressedTouchObjectSignal:IEventBusSignal
	{
		public readonly ITouchObject TouchObject;
		public PressedTouchObjectSignal( ITouchObject touchObject )
		{
			TouchObject = touchObject;
		}
	}
}
