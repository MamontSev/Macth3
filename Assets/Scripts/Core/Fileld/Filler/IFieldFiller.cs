using System;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Mathc3.Core.Item;

namespace Mathc3.Core.Field.Filler
{
	public interface IFieldFiller
	{
		UniTask<List<ItemInGame>> FillItems( int groupCount , int inGroupCount );
	}
}