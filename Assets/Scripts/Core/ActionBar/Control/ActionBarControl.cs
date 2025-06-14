using System.Collections.Generic;
using System.Linq;

using Cysharp.Threading.Tasks;

using Mathc3.Core.ActionBar.View;
using Mathc3.Core.Item;
using Mathc3.Core.Item.Animator;
using Mathc3.Data;
using Mathc3.Events;
using Mathc3.Events.Signals;

using UnityEngine;

using Zenject;

namespace Mathc3.Core.ActionBar.Control
{
	public class ActionBarControl:IActionBarControl
	{
		private IActionBarView _view;
		private IEventBusService _eventBusService;
		[Inject]
		private void Construct
		(
			IActionBarView _view ,
			IEventBusService _eventBusService
		)
		{
			this._view = _view;
			this._eventBusService = _eventBusService;
			for( int i = 0; i < GameRules.ACTION_BAR_CAPACITY; i++ )
				_items.Add(null);
		}

		private List<ItemInGame> _items = new();


		public async UniTask ResetItems()
		{
			List<UniTask> tasks = new();
			for( int i = 0; i < _items.Count; i++ )
			{
				tasks.Add(_view.HideCell(i));
				if( _items[i] != null )
				{
					tasks.Add(ItemAnimator.ScaleOnDestroy(_items[i].transform));
				}
			}
			await UniTask.WhenAll(tasks);
			foreach( var item in _items )
			{
				if( item == null )
					continue;
				GameObject.Destroy(item.gameObject);
			}
			_items.Clear();
			for( int i = 0; i < GameRules.ACTION_BAR_CAPACITY; i++ )
				_items.Add(null);

		}

		public bool HaveFreePlace => _items.Any(x => x == null);

		public async UniTask Show()
		{
			_view.HideCells();

			await _view.Show();

			List<UniTask> tasks = new();
			for( int i = 0; i < GameRules.ACTION_BAR_CAPACITY; i++ )
				tasks.Add(_view.ShowCell(i , i * 50));

			await UniTask.WhenAll(tasks);
		}

		public async UniTask Hide()
		{
			await _view.Hide();
		}

		public async void AddItem( ItemInGame item )
		{
			int index = _items.FindIndex(x => x == null);
			_items[index] = item;

			item.StartGoToActionBar();

			Vector3 cellPosition = _view.GetCellPosition(index);

			await ItemAnimator.MoveToActionBar(item.transform , GameRules.DURATION_ITEM_GOTO_ACTIONBAR , cellPosition);

			if( item != null )
			{
				item.CompleteGoToActionBar();
				CheckMatchOrFail();
			}
		}

		private bool AreAllItemsInBar
			=> _items
			.Select(x => x.SelfState)
			.ToList()
			.All(x => x == ItemInGameState.InActionBar);
		private async void CheckMatchOrFail()
		{
			MatchCalculator.CheckMatch(out List<int> indexList , in _items);

			if( indexList.Count < GameRules.MATCH_COUNT )
			{
				if( HaveFreePlace == false && AreAllItemsInBar )
					_eventBusService.Invoke(new ActionBarIsFullSignal());
				return;
			}

			List<UniTask> taskList = new();
			foreach( var index in indexList )
			{
				taskList.Add(ItemAnimator.ScaleOnMatch(_items[index].transform));
				taskList.Add(_view.HideCell(index));
			}
			await UniTask.WhenAll(taskList);
			taskList.Clear();
			foreach( var index in indexList )
			{
				GameObject.Destroy(_items[index].gameObject);
				_items[index] = null;
				taskList.Add(_view.ShowCell(index , 0));
			}
			_eventBusService.Invoke(new MatchCompleteSignal());
			await UniTask.WhenAll(taskList);
		}



	}

}
