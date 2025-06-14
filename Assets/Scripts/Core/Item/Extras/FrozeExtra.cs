using Mathc3.Events;
using Mathc3.Events.Signals;

using TMPro;

using UnityEngine;

using Zenject;

namespace Mathc3.Core.Extras
{
	public class FrozeExtra:ItemExtra
	{
		private IEventBusService _eventBusService;
		[Inject]
		private void Construct
		(
			IEventBusService _eventBusService
		)
		{
			this._eventBusService = _eventBusService;
			_mutchLeft = MutchCountToDefrost;
			CountText.text = _mutchLeft.ToString();
		}

		private void OnEnable()
		{
			_eventBusService.Subscribe<MatchCompleteSignal>(OnMatchCompleteSignal);
		}

		private void OnDisable()
		{
			_eventBusService.Subscribe<MatchCompleteSignal>(OnMatchCompleteSignal);
		}

		[SerializeField]
		private int MutchCountToDefrost = 3;
		private int _mutchLeft = 0;

		[SerializeField]
		private TextMeshPro CountText;

		private void OnMatchCompleteSignal( MatchCompleteSignal signal )
		{
			_mutchLeft--;
			if( _mutchLeft < 0 )
				_mutchLeft = 0;
			CountText.text = _mutchLeft.ToString();
		}

		public bool IsDefrost => _mutchLeft == 0;
	}
}
