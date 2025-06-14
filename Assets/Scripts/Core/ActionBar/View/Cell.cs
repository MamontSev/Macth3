using Cysharp.Threading.Tasks;

using DG.Tweening;

using UnityEngine;

namespace Mathc3.Core.ActionBar.View
{
	public class Cell:MonoBehaviour
	{
		private void Awake()
		{
			_showScale = transform.localScale;
		}
		private Vector3 _showScale;

		public async UniTask Show(int delay)
		{
			await UniTask.Delay(delay);
			await transform
		   .DOScale(_showScale , 0.2f)
		   .SetEase(Ease.OutBack)
		   .From(Vector3.zero)
		   .ToUniTask();
		}
		public async UniTask Hide()
		{
			await transform
		   .DOScale(Vector3.zero , 0.2f)
		   .SetEase(Ease.OutBack)
		   .From(_showScale)
		   .ToUniTask();
		}

		public void FastHide()
		{
			transform.localScale = Vector3.zero;
		}
	}

}
