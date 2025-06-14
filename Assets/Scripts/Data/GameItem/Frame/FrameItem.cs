using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Mathc3.Data.GameItem.Frame
{
	[Serializable]
	public class FrameItem
	{
		public FrameItem( FrameType selfType )
		{
			_selfType = selfType;
		}
		[SerializeField]
		private FrameType _selfType;
		public FrameType SelfType => _selfType;

		[SerializeField]
		private Color _selColor;
		public Color SelColor => _selColor;

	}
}


