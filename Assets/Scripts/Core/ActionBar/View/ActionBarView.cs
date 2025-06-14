using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using DG.Tweening;

using UnityEngine;

namespace Mathc3.Core.ActionBar.View
{
	public class ActionBarView:MonoBehaviour, IActionBarView
	{
		[SerializeField]
		private List<Cell> CellList;

		[SerializeField]
		private Transform MovablePanel;


		[SerializeField]								   
		private Transform HidePosition;

		[SerializeField]
		private Transform ShowPosition;

		private void Awake()
		{
			MovablePanel.transform.position = HidePosition.position;
		}

		public void HideCells()
		{
			CellList.ForEach(( x ) => x.FastHide());
		}
		public async UniTask ShowCell( int index , int delay ) => await CellList[index].Show(delay);
		public async UniTask HideCell( int index ) => await CellList[index].Hide();
		public Vector3 GetCellPosition( int index ) => CellList[index].transform.position;


		public async UniTask Show()
		{
			await MovablePanel.transform
		   .DOMove(ShowPosition.position , 1.0f)
		   .SetEase(Ease.OutBack)
		   .From(HidePosition.position)
		   .ToUniTask();
		}
		public async UniTask Hide()
		{
			await MovablePanel.transform
		   .DOMove(HidePosition.position , 1.0f)
		   .SetEase(Ease.OutBack)
		   .From(ShowPosition.position)
		   .ToUniTask();
		}
	}

}
