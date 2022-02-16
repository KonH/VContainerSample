using Sample.Service;

namespace Sample.Manager {
	public sealed class EntryPointManager {
		readonly SceneLoader _sceneLoader;

		public EntryPointManager(SceneLoader sceneLoader) {
			_sceneLoader = sceneLoader;
		}

		public void Start() => _sceneLoader.LoadSampleScene();
	}
}