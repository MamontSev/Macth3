using System;

using Mathc3.Core.Field.Control;
using Mathc3.Core.Loop;
using Mathc3.Events;
using Mathc3.Events.Signals;

namespace Mathc3.Core.Shaffle
{
	public class ShaffleListener:IDisposable
	{
		private readonly IEventBusService _eventBusService;
		private readonly IGameLoop _gameLoop;
		private readonly IFieldControl _fieldControl;
		public ShaffleListener
		(
			 IEventBusService _eventBusService,
			 IGameLoop _gameLoop,
			 IFieldControl _fieldControl
		)
        {
			this._eventBusService = _eventBusService;
			this._gameLoop = _gameLoop;
			this._fieldControl = _fieldControl;
			Subscribe();
		}

		private void OnPressedTouchObjectSignal( PressedTouchObjectSignal signal )
		{
			if( !_gameLoop.IsPlayMode )
				return;
			if( signal.TouchObject is not ShaffleButton restartButton )
				return;
			_fieldControl.ShaffleItems();
		}


		private void Subscribe()
		{
			_eventBusService.Subscribe<PressedTouchObjectSignal>(OnPressedTouchObjectSignal);
		}
		private void Unsubscribe()
		{
			_eventBusService.Unsubscribe<PressedTouchObjectSignal>(OnPressedTouchObjectSignal);
		}


		public void Dispose()
		{
			Unsubscribe();
		}
	}
}
