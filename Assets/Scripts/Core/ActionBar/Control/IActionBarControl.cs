using System;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Mathc3.Core.Item;

using UnityEngine;

namespace Mathc3.Core.ActionBar.Control
{
	public interface IActionBarControl
	{
		bool HaveFreePlace
		{
			get;
		}

		void AddItem( ItemInGame item );
		UniTask Hide();	  
		UniTask ResetItems();
		UniTask Show();
	}
}