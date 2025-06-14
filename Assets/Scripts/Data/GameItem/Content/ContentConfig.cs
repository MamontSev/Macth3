using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Mathc3.Data.GameItem.Content
{
	public class ContentConfig
	{
		private readonly ContentPreset _data;
		public ContentConfig( ContentPreset data )
		{
			_data = data;
		}

		public Sprite GetSprite( ContentType type ) => _dataDict[type];

		private readonly Dictionary<ContentType , Sprite> _dataDict = new();

		public void Validate()
		{
			List<ContentType> typeList = _data.ItemList.Select(x => x.SelfType).ToList();
			foreach( ContentType type in Enum.GetValues(typeof(ContentType)) )
			{
				if( typeList.Contains(type) == false )
				{
					throw new Exception($"ContentPreset not contains `{type}`");
				}
			}
			foreach( var item in _data.ItemList )
			{
				if( item.SelfSprite == null )
				{
					throw new Exception($"ContentPreset Sprite is null `{item.SelfType}`");
				}
				_dataDict.Add(item.SelfType , item.SelfSprite);

			}
		}
	}
}


