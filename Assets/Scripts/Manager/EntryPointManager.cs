using Sample.Service;

namespace Sample.Manager {
	public sealed class EntryPointManager {
		readonly SceneLoader _sceneLoader;
		readonly IAnalyticsService _analytics;

		public EntryPointManager(SceneLoader sceneLoader, IAnalyticsService analytics) {
			_sceneLoader = sceneLoader;
			_analytics = analytics;
		}

		public void Start() {
			_sceneLoader.LoadSampleScene();
			_analytics.SendEvent("Start");
		}
	}
}