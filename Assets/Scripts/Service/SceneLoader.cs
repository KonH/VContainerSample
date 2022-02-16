using UnityEngine.SceneManagement;

namespace Sample.Service {
	public sealed class SceneLoader {
		public void LoadSampleScene() => SceneManager.LoadScene(1);
	}
}