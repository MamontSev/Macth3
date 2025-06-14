using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Mathc3.Data.GameItem.Content
{
	[Serializable]
	public class ContentItem
	{
		public ContentItem( ContentType selfType )
		{
			_selfType = selfType;
		}
		[SerializeField]
		private ContentType _selfType;
		public ContentType SelfType => _selfType;

		[SerializeField]
		private Sprite _selfSprite;
		public Sprite SelfSprite => _selfSprite;

	}
}


