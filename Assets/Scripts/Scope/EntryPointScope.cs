using Sample.Manager;
using Sample.Starter;
using VContainer;
using VContainer.Unity;

namespace Sample.Scope {
	public sealed class EntryPointScope : LifetimeScope {
		protected override void Configure(IContainerBuilder builder) {
			builder.RegisterEntryPoint<EntryPointStarter>();
			builder.Register<EntryPointManager>(Lifetime.Scoped);
		}
	}
}