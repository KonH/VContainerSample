using UnityEngine;

namespace Sample.Service {
	public sealed class EditorAnalytics : IAnalyticsService {
		public void SendEvent(string name) =>
			Debug.Log($"EditorAnalytics.SendEvent: '{name}'");
	}
}