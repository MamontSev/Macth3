using Mathc3.Core.Item;

using UnityEngine;

namespace Mathc3.Core.Extras
{
	public abstract class ItemExtra:MonoBehaviour
	{
		protected ItemInGame _selfItem;
		public virtual void Init( ItemInGame _selfItem )
		{
			this._selfItem = _selfItem;
		}
	}
}
