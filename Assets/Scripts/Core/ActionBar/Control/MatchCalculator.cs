using System.Collections.Generic;

using Mathc3.Core.Item;
using Mathc3.Data;

namespace Mathc3.Core.ActionBar.Control
{
	public static class MatchCalculator
	{
		public static void CheckMatch( out List<int> indexList , in List<ItemInGame> items )
		{
			ItemInGameType currType;
			indexList = new();
			for( int i = 0; i <= items.Count - GameRules.MATCH_COUNT; i++ )
			{
				indexList.Clear();
				if( IsValidItem(items[i]) == false )
					continue;
				indexList.Add(i);
				currType = items[i].SelfItemType;
				for( int j = i + 1; j < items.Count; j++ )
				{
					if( IsValidItem(items[j]) == false )
						continue;
					if( items[j].SelfItemType.Equals(currType) )
					{
						indexList.Add(j);
						if( indexList.Count == GameRules.MATCH_COUNT )
						{
							return;
						}
					}
				}
			}
		}

		private static bool IsValidItem( ItemInGame item)
		{
			if( item == null )
				return false;
			if( item.SelfState != ItemInGameState.InActionBar )
				return false;
			return true;
		}
	}

}
