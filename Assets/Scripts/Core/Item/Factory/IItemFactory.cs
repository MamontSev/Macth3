using Mathc3.Core.Extras;

using UnityEngine;

namespace Mathc3.Core.Item.Factory
{
	public interface IItemFactory
	{
		ItemInGame GetItem( ItemInGameType itemType , Transform itemContainer , ItemExtra itemExtraPrefab );
	}
}