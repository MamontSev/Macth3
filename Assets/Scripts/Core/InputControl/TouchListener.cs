using Mathc3.Core.GameCamera;
using Mathc3.Events;
using Mathc3.Events.Signals;

using UnityEngine;
using UnityEngine.EventSystems;

using Zenject;

namespace Mathc3.Core.InputControl
{
	public class TouchListener:ITickable
	{
		private readonly IGameCameraControl _gameCameraControl;
		private readonly IEventBusService _eventBusService;
		public TouchListener
		(
			IGameCameraControl _gameCameraControl ,
			IEventBusService _eventBusService
		)
        {
			this._gameCameraControl = _gameCameraControl;
			this._eventBusService = _eventBusService;
		}
        public void Tick()
		{
			UpdateTouch();
		}
		private Vector2 _pressedPos;
		private int _fingerIdMove = -1;
		private void UpdateTouch()
		{
			if( _fingerIdMove == -1 )
			{
				foreach( Touch _t in Input.touches )
				{
					if( _t.phase != TouchPhase.Began )
					{
						break;
					}
					if( EventSystem.current.IsPointerOverGameObject(_t.fingerId) )
					{
						break;
					}
					_fingerIdMove = _t.fingerId;
					_pressedPos = _t.position;
					break;
				}
			}
			else
			{
				foreach( Touch _t in Input.touches )
				{
					if( _t.phase == TouchPhase.Ended )
					{
						CheckEnded(_t);
					}
				}
			}

			void CheckEnded( Touch _t )
			{
				if( _fingerIdMove != _t.fingerId )
				{
					return;
				}
				_fingerIdMove = -1;

				if( Vector2.Distance(_pressedPos , _t.position) > 10.0f )
				{
					return;
				}


				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(_t.position.x , _t.position.y , 0.0f)) , Vector2.zero);

				if( hit.collider != null )
				{
					bool b = hit.transform.TryGetComponent(out ITouchObject touchObject);
					if( b == true )
					{
						_eventBusService.Invoke(new PressedTouchObjectSignal(touchObject));
					}
				}

			}
		}
	}
}
