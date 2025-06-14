using System;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Mathc3.Core.Extras;
using Mathc3.Core.Item;
using Mathc3.Core.Item.Factory;
using Mathc3.Data.GameItem;
using Mathc3.Tools;

using UnityEngine;

using Zenject;

namespace Mathc3.Core.Field.Filler
{
	public class FieldFiller:MonoBehaviour, IFieldFiller
	{
		private IItemFactory _itemFactory;
		[Inject]
		private void Construct
		(
			IItemFactory _itemFactory
		)
		{
			this._itemFactory = _itemFactory;
			_extraDict.Add(typeof(WeightExtra) , WeightExtra);
			_extraDict.Add(typeof(FrozeExtra) , FrozeExtra);
		}

		[SerializeField]
		private Transform ItemSpawnPoint;
		[SerializeField]
		private Transform ItemSpawnContainer;

		[SerializeField]
		private WeightExtra WeightExtra;
		[SerializeField]
		private FrozeExtra FrozeExtra;

		private readonly Dictionary<Type , ItemExtra> _extraDict = new();



		public async UniTask<List<ItemInGame>> FillItems( int groupCount , int inGroupCount)
		{
			List<ItemInGame> itemList = new();
			CreateItemTypeList(out List<(ItemInGameType type, ItemExtra extra)> itemTypeList , groupCount , inGroupCount);

			List<UniTask> tasks = new();
			for( int i = 0; i < itemTypeList.Count; i++ )
			{
				tasks.Add(CreateItem(itemTypeList[i].type , itemTypeList[i].extra , i));
			}
			await UniTask.WhenAll(tasks);

			return itemList;

			async UniTask CreateItem( ItemInGameType type , ItemExtra extra , int index )
			{
				await UniTask.Delay(index * 200);
				ItemInGame item = _itemFactory.GetItem(type , ItemSpawnContainer , extra);
				item.transform.position = ItemSpawnPoint.position;
				itemList.Add(item);
			}
		}



		private void CreateItemTypeList( out List<(ItemInGameType type, ItemExtra extra)> itemTypeList , int groupCount , int inGroupCount )
		{
			List<Type> extrasList = new();
			extrasList.Add(typeof(WeightExtra));
			if( groupCount > 3 )
			{
				extrasList.Add(typeof(FrozeExtra));
			}

			itemTypeList = new();

			for( int i = 0; i < groupCount; i++ )
			{
				ShapeType shapeType = (ShapeType)UnityEngine.Random.Range(0 , GetEnumLength(typeof(ShapeType)));
				FrameType frameType = (FrameType)UnityEngine.Random.Range(0 , GetEnumLength(typeof(FrameType)));
				ContentType contentType = (ContentType)UnityEngine.Random.Range(0 , GetEnumLength(typeof(ContentType)));
				for( int j = 0; j < inGroupCount; j++ )
				{
					ItemInGameType obj = new ItemInGameType(shapeType , frameType , contentType);
					ItemExtra extra = null;
					if( extrasList.Count > 0 )
					{
						extra = _extraDict[extrasList[0]];
						extrasList.RemoveAt(0);
					}
					itemTypeList.Add((obj, extra));
				}
			}

			itemTypeList.Shuffle();

			static int GetEnumLength( Type type ) => Enum.GetValues(type).Length;
		}

	}


}
