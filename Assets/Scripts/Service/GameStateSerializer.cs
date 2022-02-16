using Sample.State;
using UnityEngine;

namespace Sample.Service {
	public sealed class GameStateSerializer : IGameStateSaver {
		const string PrefsKey = "GameState";

		GameState _gameState;

		public GameState LoadGameState() {
			var json = PlayerPrefs.GetString(PrefsKey, string.Empty);
			_gameState = !string.IsNullOrWhiteSpace(json) ? JsonUtility.FromJson<GameState>(json) : new GameState();
			return _gameState;
		}

		public void SaveGameState() {
			var json = JsonUtility.ToJson(_gameState);
			PlayerPrefs.SetString(PrefsKey, json);
			PlayerPrefs.Save();
		}
	}
}