using Sample.State;
using UnityEngine;
using VContainer.Unity;

namespace Sample.Service {
	public sealed class ClickService : ITickable {
		public bool CanClick { get; private set; } = true;

		public int ClickCount => _state.ClickCount;

		float ClickCooldown => 3.0f / (1 + _upgradeService.UpgradeLevel);

		int ClickIncome => (_upgradeService.UpgradeLevel + 1) * 5;

		float _lastClickTime = float.MinValue;

		readonly ClickState _state;
		readonly UpgradeService _upgradeService;
		readonly CoinService _coinService;
		readonly IGameStateSaver _saver;
		readonly IAnalyticsService _analytics;

		public ClickService(ClickState state, UpgradeService upgradeService, CoinService coinService, IGameStateSaver saver, IAnalyticsService analytics) {
			_state = state;
			_upgradeService = upgradeService;
			_coinService = coinService;
			_saver = saver;
			_analytics = analytics;
		}

		public void Tick() =>
			CanClick = Time.realtimeSinceStartup > _lastClickTime + ClickCooldown;

		public void Click() {
			_lastClickTime = Time.realtimeSinceStartup;
			_state.ClickCount++;
			_coinService.Increase(ClickIncome);
			_saver.SaveGameState();
			_analytics.SendEvent($"Click_{_state.ClickCount}");
		}
	}
}