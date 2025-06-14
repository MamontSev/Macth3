using Mathc3.Core.Item;

using UnityEngine;
namespace Mathc3.Core.Extras
{
	public class WeightExtra:ItemExtra
	{
		[SerializeField]
		private float GravityScale = 2.0f;

		public override void Init( ItemInGame _selfItem )
		{
			base.Init(_selfItem);
			this._selfItem = _selfItem;
			_selfItem.GetComponent<Rigidbody2D>().gravityScale = GravityScale;
		}
	}
}
