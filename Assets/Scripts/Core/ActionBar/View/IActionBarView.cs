using Cysharp.Threading.Tasks;

using UnityEngine;

namespace Mathc3.Core.ActionBar.View
{
	public interface IActionBarView
	{
		Vector3 GetCellPosition( int index );
		UniTask Hide();
		UniTask HideCell( int index );
		void HideCells();
		UniTask Show();
		UniTask ShowCell( int index , int delay );
	}
}