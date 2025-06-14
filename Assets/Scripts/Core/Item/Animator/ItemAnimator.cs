using Cysharp.Threading.Tasks;

using DG.Tweening;

using UnityEngine;

namespace Mathc3.Core.Item.Animator
{
	public static class ItemAnimator
	{
		public static async UniTask MoveToActionBar( Transform target , float duration , Vector3 movePosition )
		{
			UniTask rotate = target
		   .DORotate(Vector3.zero , duration , RotateMode.Fast)
		   .ToUniTask();

			UniTask move = target
			.DOMove(movePosition , duration)
			.SetEase(Ease.InCubic)
			.From(target.position)
			.ToUniTask();

			await UniTask.WhenAll(rotate , move);
		}

		public static async UniTask ScaleOnMatch( Transform target )
		{
			await target
		   .DOScale(Vector3.zero , 0.4f)
		   .From(target.localScale)
		   .SetEase(Ease.InOutBounce)
		   .ToUniTask();
		}

		public static async UniTask ScaleOnDestroy( Transform target )
		{
			await target
		   .DOScale(Vector3.zero , 0.4f)
		   .From(target.localScale)
		   .SetEase(Ease.InOutBounce)
		   .ToUniTask();
		}
	}


}
