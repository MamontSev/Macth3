using System;
using System.Collections.Generic;
using System.Linq;

using Mathc3.Core.Item;

using UnityEngine;

namespace Mathc3.Data.GameItem.Shape
{
	public class ShapeConfig					 
	{
		private readonly ShapePreset _data;
		public ShapeConfig( ShapePreset data )
		{
			_data = data;
		}

		public ItemInGame GetPrefab( ShapeType type ) => _dataDict[type];

		private readonly Dictionary<ShapeType , ItemInGame> _dataDict = new();

		public void Validate()
		{
			List<ShapeType> typeList = _data.ItemList.Select(x => x.SelfType).ToList();
			foreach( ShapeType type in Enum.GetValues(typeof(ShapeType)) )
			{
				if( typeList.Contains(type) == false )
				{
					throw new Exception($"ShapePreset not contains `{type}`");
				}
			}
			foreach( var item in _data.ItemList )
			{
				if( item.SelfPrefab == null )
				{
					throw new Exception($"ShapePreset Prefab is null `{item.SelfType}`");
				}
				_dataDict.Add(item.SelfType , item.SelfPrefab);
			}
		}
	}
}


