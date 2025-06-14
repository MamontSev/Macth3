using Mathc3.Core.Extras;
using Mathc3.Data.GameItem.Content;
using Mathc3.Data.GameItem.Frame;
using Mathc3.Data.GameItem.Shape;

using UnityEngine;

using Zenject;

namespace Mathc3.Core.Item.Factory
{

	public class ItemFactory:IItemFactory
	{
		private DiContainer _diContainer;
		private ShapeConfig _shapeConfig;
		private FrameConfig _frameConfig;
		private ContentConfig _contentConfig;
		[Inject]
		private void Construct
		(
			DiContainer _diContainer ,
			ShapeConfig _shapeConfig ,
			FrameConfig _frameConfig ,
			ContentConfig _contentConfig
		)
		{
			this._diContainer = _diContainer;
			this._shapeConfig = _shapeConfig;
			this._frameConfig = _frameConfig;
			this._contentConfig = _contentConfig;
		}

		public ItemInGame GetItem( ItemInGameType itemType , Transform itemContainer , ItemExtra itemExtraPrefab )
		{

			ItemInGame item = _diContainer
			.InstantiatePrefabForComponent<ItemInGame>
			(
			  _shapeConfig.GetPrefab(itemType.SelfShapeType) ,
			  itemContainer ,
			   new object[] { itemType }
			);

			if( itemExtraPrefab != null )
			{
				ItemExtra extra = _diContainer.InstantiatePrefabForComponent<ItemExtra>(itemExtraPrefab,item.transform);
				item.SetExtra(extra);
			}

			item.InitSkin(
			   _frameConfig.GetSprite(itemType.SelfFrameType) ,
			   _contentConfig.GetSprite(itemType.SelfContentType));

			return item;
		}
	}
}
