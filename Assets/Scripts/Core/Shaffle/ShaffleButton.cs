using Cysharp.Threading.Tasks;

using DG.Tweening;

using Mathc3.Core.InputControl;

using UnityEngine;

namespace Mathc3.Core.Shaffle
{
	public class ShaffleButton:MonoBehaviour, ITouchObject
	{
		[SerializeField]
		private Transform HidePosition;

		[SerializeField]
		private Transform ShowPosition;
		private void Awake()
		{
			transform.position = HidePosition.position;
		}

		public async UniTask Show()
		{
			await transform
		   .DOMove(ShowPosition.position , 1.0f)
		   .SetEase(Ease.OutBack)
		   .From(HidePosition.position)
		   .ToUniTask();
		}
		public async UniTask Hide()
		{
			await transform
		   .DOMove(HidePosition.position , 1.0f)
		   .SetEase(Ease.OutBack)
		   .From(ShowPosition.position)
		   .ToUniTask();
		}
	}
}
