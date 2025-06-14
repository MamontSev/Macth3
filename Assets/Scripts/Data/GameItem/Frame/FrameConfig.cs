using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Mathc3.Data.GameItem.Frame
{
	public class FrameConfig
	{
		private readonly FramePreset _data;
		public FrameConfig( FramePreset data )
		{
			_data = data;
		}

		public Color GetSprite( FrameType type ) => _dataDict[type];

		private readonly Dictionary<FrameType , Color> _dataDict = new();

		public void Validate()
		{
			List<FrameType> typeList = _data.ItemList.Select(x => x.SelfType).ToList();
			foreach( FrameType type in Enum.GetValues(typeof(FrameType)) )
			{
				if( typeList.Contains(type) == false )
				{
					throw new Exception($"FramePreset not contains `{type}`");
				}
			}
			foreach( var item in _data.ItemList )
			{
				_dataDict.Add(item.SelfType , item.SelColor);
			}
		}
	}
}


