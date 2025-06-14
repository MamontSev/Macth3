using System;
using System.Collections.Generic;

using Mathc3.Log;
using Mathc3.UI.MVVM;

using UnityEngine;

using Zenject;
														   
namespace Mathc3.UI.General.PopUp
{
	public abstract class BasePopUpFactory:MonoBehaviour, IBasePopUpFactory
	{
		protected ILogService _logService;
		protected DiContainer _diContainer;

		private void Awake()
		{
			InitPrefabs();
		}
		private void Update()
		{
			CheckBackButton();
		}
		[SerializeField]
		private Transform _container;


		protected readonly Dictionary<Type , GameObject> _prefabDict = new();
		protected abstract void InitPrefabs();

		protected List<IPopUpView> _viewedItems = new();

	

		public virtual void Show<T>( T vm ) where T : IPopUpViewModel
		{
			var t = typeof(T);
			if( _prefabDict.ContainsKey(t) == false )
			{
				string s = $"Fail create PopUp Page  {t.Name} not exist prefab";
				_logService.LogError(s);
				throw new Exception(s);
			}
			_diContainer.Inject(vm);
			GameObject itemGo = _diContainer.InstantiatePrefab(_prefabDict[t] , _container);
			IPopUpView item = itemGo.GetComponent<IPopUpView>();
			_diContainer.InjectGameObject(itemGo);
			item.Bind(vm);
			item.Show(OnClozeItem);

			_viewedItems.Add(item);
		}


		protected virtual void OnClozeItem( IPopUpView item )
		{
			if( _viewedItems.Contains(item) )
			{
				_viewedItems.Remove(item);
			}
			else
			{
				string s = $"Fail remove item PopUpHolder.OnClozeItem {item}";
				_logService.LogError(s);
			}
		}

		private void TryClozeOnBackButton()
		{
			if( _viewedItems.Count == 0 )
			{
				return;
			}
			int pos = _viewedItems.Count - 1;
			if( _viewedItems[pos] is not IHideOnSystemBack )
			{
				return;
			}
			_viewedItems[pos].Hide();
		}
		private void CheckBackButton()
		{
			if( Input.GetKeyDown(KeyCode.Escape) )
			{
				TryClozeOnBackButton();
			}
		}


	}
}
