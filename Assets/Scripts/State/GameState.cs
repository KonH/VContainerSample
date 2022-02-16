using System;

namespace Sample.State {
	[Serializable]
	public sealed class GameState {
		public ClickState ClickState = new ClickState();
		public UpgradeState UpgradeState = new UpgradeState();
		public CoinState CoinState = new CoinState();
	}
}