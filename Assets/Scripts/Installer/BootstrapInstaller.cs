using Mathc3.Data.GameItem.Content;
using Mathc3.Data.GameItem.Frame;
using Mathc3.Data.GameItem.Shape;
using Mathc3.Events;
using Mathc3.GeneralStateMashine;
using Mathc3.Log;
using Mathc3.SceneControl;
using Mathc3.UI.General.Loading;

using UnityEngine;

using Zenject;

namespace Mathc3.Installer
{
	public class BootstrapInstaller:MonoInstaller
	{
		public override void InstallBindings()
		{
			BindLoadingPanel();
			BindSceneControlService();
			BindGeneralGameStateMachine();
			BindBusService();
			BindLogService();
			BindShapeConfig();
			BindFrameConfig();
			BindContentConfig();
		}

		[SerializeField]
		private LoadingPanel _loadingPanel;
		private void BindLoadingPanel()
		{
			Container
			.Bind<ILoadingPanel>()
			.To<LoadingPanel>()
			.FromInstance(_loadingPanel)
			.AsSingle()
			.NonLazy();
		}

		private void BindSceneControlService()
		{
			Container
			.Bind<ISceneControlService>()
			.To<SceneControlService>()
			.AsSingle()
			.NonLazy();
		}

		private void BindGeneralGameStateMachine()
		{
			Container.Bind<GeneralGameStateMachine>().AsSingle().NonLazy();
			Container.Bind<GeneralStateFactory>().AsSingle().NonLazy();
		}

		private void BindBusService()
		{
			Container.Bind<IEventBusService>().To<EventBusService>().AsSingle().NonLazy();
		}

		private void BindLogService()
		{
			Container.Bind<ILogService>().To<LogService>().AsSingle().NonLazy();
		}

		[SerializeField]
		private ShapePreset _shapePreset;
		private void BindShapeConfig()
		{
			Container
				.Bind<ShapeConfig>()
				.AsSingle()
				.WithArguments(_shapePreset)
				.NonLazy();
		}


		[SerializeField]
		private FramePreset _framePreset;
		private void BindFrameConfig()
		{
			Container
				.Bind<FrameConfig>()
				.AsSingle()
				.WithArguments(_framePreset)
				.NonLazy();
		}

		[SerializeField]
		private ContentPreset _contentPreset;
		private void BindContentConfig()
		{
			Container
				.Bind<ContentConfig>()
				.AsSingle()
				.WithArguments(_contentPreset)
				.NonLazy();
		}

	}
}
