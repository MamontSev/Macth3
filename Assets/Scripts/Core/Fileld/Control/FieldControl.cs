using System;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Mathc3.Core.ActionBar.Control;
using Mathc3.Core.Extras;
using Mathc3.Core.Field.Filler;
using Mathc3.Core.Item;
using Mathc3.Core.Item.Animator;
using Mathc3.Core.Loop;
using Mathc3.Core.Shaffle;
using Mathc3.Data;
using Mathc3.Events;
using Mathc3.Events.Signals;
using Mathc3.UI.GamePlay.PopUp;

using UnityEngine;

namespace Mathc3.Core.Field.Control
{
	public class FieldControl:IFieldControl, IDisposable
	{
		private readonly IFieldFiller _fieldFiller;
		private readonly IEventBusService _eventBusService;
		private readonly IGameLoop _gameLoop;
		private readonly IActionBarControl _actionBarControl;
		private readonly GamePlayPopUpFactory _gamePlayPopUpFactory;
		private readonly ShaffleButton _shaffleButton;
		public FieldControl
		(
			IFieldFiller _fieldFiller ,
			IEventBusService _eventBusService ,
			IGameLoop _gameLoop ,
			IActionBarControl _actionBarControl ,
			GamePlayPopUpFactory _gamePlayPopUpFactory ,
			ShaffleButton _shaffleButton
		)
		{
			this._fieldFiller = _fieldFiller;
			this._eventBusService = _eventBusService;
			this._gameLoop = _gameLoop;
			this._actionBarControl = _actionBarControl;
			this._gamePlayPopUpFactory = _gamePlayPopUpFactory;
			this._shaffleButton = _shaffleButton;
			Subscribe();
		}

		public async UniTaskVoid InitOnStart()
		{
			_gameLoop.AwaitGame();

			_currGroupCount = GameRules.ITEM_GROUP_COUNT;
			_fieldItems = await _fieldFiller.FillItems(_currGroupCount , GameRules.ITEM_IN_GROUP_COUNT);

			await UniTask.Delay(700);

			UniTask bar = _actionBarControl.Show();
			UniTask shaffleButton = _shaffleButton.Show();
			await UniTask.WhenAll(bar, shaffleButton);

			_gameLoop.StartGame();
		}

		public async UniTaskVoid ReplayOnWinOrLose()
		{
			_gameLoop.AwaitGame();

			await UniTask.Delay(500);

			await Restart(GameRules.ITEM_GROUP_COUNT);

			_gameLoop.StartGame();
		}

		public async UniTaskVoid ShaffleItems()
		{
			_gameLoop.AwaitGame();

			await Restart(_currGroupCount);

			_gameLoop.StartGame();
		}

		private async UniTask Restart( int newGroupCount )
		{
			List<UniTask> tasks = new();
			tasks.Add(_actionBarControl.ResetItems());
			foreach( var item in _fieldItems )
			{
				tasks.Add(ItemAnimator.ScaleOnDestroy(item.transform));
			}
			await UniTask.WhenAll(tasks);

			foreach( var item in _fieldItems )
			{
				GameObject.Destroy(item.gameObject);
			}

			UniTask bar = _actionBarControl.Hide();
			UniTask shaffleButton = _shaffleButton.Hide();
			await UniTask.WhenAll(bar , shaffleButton);

			_currGroupCount = newGroupCount;
			_fieldItems = await _fieldFiller.FillItems(_currGroupCount , GameRules.ITEM_IN_GROUP_COUNT);

			await UniTask.Delay(700);

			bar = _actionBarControl.Show();
			shaffleButton = _shaffleButton.Show();
			await UniTask.WhenAll(bar , shaffleButton);
		}


		private int _currGroupCount;

		private List<ItemInGame> _fieldItems = new();
		private void OnPressedTouchObjectSignal( PressedTouchObjectSignal signal )
		{
			if( !_gameLoop.IsPlayMode )
				return;
			if( signal.TouchObject is not ItemInGame item )
				return;
			if( !item.CanTakeMe )
				return;
			if( !_fieldItems.Contains(item) )
				return;
			if( _actionBarControl.HaveFreePlace == false )
				return;

			ItemToActionBar(item);
		}

		private void ItemToActionBar( ItemInGame item )
		{
			item.StartGoToActionBar();
			_fieldItems.Remove(item);
			_actionBarControl.AddItem(item);
		}

		private void OnActionBarIsFullSignal( ActionBarIsFullSignal signal )
		{
			_gamePlayPopUpFactory.Show(new WinLoseMenuViewModel("You Lose"));
		}

		private void OnMatchCompleteSignal( MatchCompleteSignal signal )
		{
			_currGroupCount--;
			if( _currGroupCount == 0 )
			{
				_gamePlayPopUpFactory.Show(new WinLoseMenuViewModel("You Win"));
			}
		}


		private void Subscribe()
		{
			_eventBusService.Subscribe<PressedTouchObjectSignal>(OnPressedTouchObjectSignal);
			_eventBusService.Subscribe<MatchCompleteSignal>(OnMatchCompleteSignal);
			_eventBusService.Subscribe<ActionBarIsFullSignal>(OnActionBarIsFullSignal);
		}
		private void Unsubscribe()
		{
			_eventBusService.Unsubscribe<PressedTouchObjectSignal>(OnPressedTouchObjectSignal);
			_eventBusService.Unsubscribe<MatchCompleteSignal>(OnMatchCompleteSignal);
			_eventBusService.Unsubscribe<ActionBarIsFullSignal>(OnActionBarIsFullSignal);
		}



		public void Dispose()
		{
			Unsubscribe();
		}
	}


}
