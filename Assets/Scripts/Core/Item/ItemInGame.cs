using System;

using Mathc3.Core.Extras;
using Mathc3.Core.InputControl;

using UnityEngine;

using Zenject;

namespace Mathc3.Core.Item
{
	[RequireComponent(typeof(PolygonCollider2D))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class ItemInGame:MonoBehaviour, ITouchObject
	{
		private ItemInGameType _selfItemType;
		
		[Inject]
		private void Construct
		(
			ItemInGameType _selfItemType
		)
		{
			this._selfItemType = _selfItemType;
			SelfState = ItemInGameState.InField;
		}

		[SerializeField]
		private SpriteRenderer Frame;

		[SerializeField]
		private SpriteRenderer Content;

		private ItemExtra _extra = null;
		public void SetExtra( ItemExtra _extra )
		{
			this._extra = _extra;
			_extra.Init(this);
		}



		public ItemInGameType SelfItemType => _selfItemType;

		public void InitSkin( Color frameColor , Sprite content )
		{
			Frame.color = frameColor;
			Content.sprite = content;
		}

		public void StartGoToActionBar()
		{
			SelfState = ItemInGameState.GoToActionBar;
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		}
		public void CompleteGoToActionBar()
		{
			SelfState = ItemInGameState.InActionBar;
			GetComponent<PolygonCollider2D>().enabled = false;
			GetComponent<Rigidbody2D>().simulated = false;
		}

		public bool CanTakeMe
		{
			get
			{
				if( _extra is FrozeExtra frozen )
					return frozen.IsDefrost;
				return true;
			}
		}

		public ItemInGameState SelfState
		{
			private set;
			get;
		}

	}
}
