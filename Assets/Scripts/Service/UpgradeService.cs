using Sample.State;
using UnityEngine;
using VContainer.Unity;

namespace Sample.Service {
	public sealed class UpgradeService {
		public int UpgradeLevel => _state.UpgradeLevel;
		public int UpgradePrice => 10 + UpgradeLevel * 10;

		readonly UpgradeState _state;
		readonly CoinService _coinService;
		readonly IGameStateSaver _saver;

		public UpgradeService(UpgradeState state, CoinService coinService, IGameStateSaver saver) {
			_state = state;
			_coinService = coinService;
			_saver = saver;
		}

		public bool CanUpgrade() => _coinService.IsEnough(UpgradePrice);

		public void Upgrade() {
			_coinService.Consume(UpgradePrice);
			_state.UpgradeLevel++;
			_saver.SaveGameState();
		}
	}
}