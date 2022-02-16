using Sample.Service;
using Sample.Starter;
using Sample.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Sample.Scope {
	public sealed class SampleSceneScope : LifetimeScope {
		[SerializeField] ClickEffectView _clickEffectView;
		[SerializeField] UpgradeWindow _upgradeWindow;

		protected override void Configure(IContainerBuilder builder) {
			builder.RegisterEntryPoint<SampleSceneStarter>();
			builder.Register<ClickService>(Lifetime.Scoped)
				.AsSelf()
				.As<ITickable>();
			builder.Register<UpgradeService>(Lifetime.Scoped);
			builder.RegisterInstance(_upgradeWindow);
			builder
				.RegisterFactory<int, ClickEffectView>(resolver => {
					return clickCount => {
						var view = resolver.Instantiate(_clickEffectView);
						view.Init(clickCount);
						return view;
					};
				}, Lifetime.Transient);
			// Alternative implicit way:
			/*builder
				.RegisterFactory<ClickEffectView>(container => {
					return () => {
						var clickService = container.Resolve<ClickService>();
						var view = container.Instantiate(_clickEffectView);
						view.Init(clickService.ClickCount);
						return view;
					};
				}, Lifetime.Transient);*/
		}
	}
}