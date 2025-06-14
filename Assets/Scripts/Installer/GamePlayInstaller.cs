using Mathc3.Core.ActionBar.Control;
using Mathc3.Core.ActionBar.View;
using Mathc3.Core.Field.Control;
using Mathc3.Core.Field.Filler;
using Mathc3.Core.GameCamera;
using Mathc3.Core.InputControl;
using Mathc3.Core.Item.Animator;
using Mathc3.Core.Item.Factory;
using Mathc3.Core.Loop;
using Mathc3.Core.Shaffle;
using Mathc3.UI.GamePlay.PopUp;

using Zenject;

namespace Mathc3.Installer
{
	public class GamePlayInstaller:MonoInstaller
	{
		public override void InstallBindings()
		{
			BindItemFactory();
			BindFieldControl();
			BindFieldFiller();
			BindActionBarView();
			BindActionBarControl();
			BindGameLoop();
			BindTouchListener();
			BindGameCameraControl();
			BindShaffleListener();
			BindGamePlayPopUpFactory();
			BindShaffleButton();
		}

		private void BindItemFactory()
		{
			Container
			.Bind<IItemFactory>()
			.To<ItemFactory>()
			.AsSingle()
			.NonLazy();
		}
		private void BindFieldControl()
		{
			Container
			.BindInterfacesAndSelfTo<FieldControl>()
			.AsSingle()
			.NonLazy();
		}
		private void BindFieldFiller()
		{
			Container
			.Bind<IFieldFiller>()
			.To<FieldFiller>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}
		private void BindActionBarView()
		{
			Container
			.Bind<IActionBarView>()
			.To<ActionBarView>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}
		private void BindActionBarControl()
		{
			Container
			.Bind<IActionBarControl>()
			.To<ActionBarControl>()
			.AsSingle()
			.NonLazy();
		}

		private void BindGameLoop()
		{
			Container
			.BindInterfacesAndSelfTo<GameLoop>()
			.AsSingle()
			.NonLazy();
		}
		private void BindTouchListener()
		{
			Container
			.BindInterfacesAndSelfTo<TouchListener>()
			.AsSingle()
			.NonLazy();
		}
		private void BindGameCameraControl()
		{
			Container
			.Bind<IGameCameraControl>()
			.To<GameCameraControl>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}
		private void BindShaffleListener()
		{
			Container
			.BindInterfacesAndSelfTo<ShaffleListener>()
			.AsSingle()
			.NonLazy();
		}
		private void BindGamePlayPopUpFactory()
		{
			Container
			.Bind<GamePlayPopUpFactory>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}
		private void BindShaffleButton()
		{
			Container
			.Bind<ShaffleButton>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

		






	}
}
