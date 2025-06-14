using System;
using System.Collections.Generic;
using System.Linq;

using Mathc3.Core.Item;

using UnityEngine;

namespace Mathc3.Data.GameItem.Shape
{
	[Serializable]
	public class ShapeItem
	{
		public ShapeItem( ShapeType selfType )
		{
			_selfType = selfType;
		}
		[SerializeField]
		private ShapeType _selfType;
		public ShapeType SelfType => _selfType;

		[SerializeField]
		private ItemInGame _selfPrefab;
		public ItemInGame SelfPrefab => _selfPrefab;

	}
}


