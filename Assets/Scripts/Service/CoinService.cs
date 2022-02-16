using Sample.State;

namespace Sample.Service {
	public sealed class CoinService {
		public int Coins => _state.Coins;

		readonly CoinState _state;

		public CoinService(CoinState state) {
			_state = state;
		}

		public bool IsEnough(int count) => Coins >= count;

		public void Consume(int count) {
			_state.Coins -= count;
		}

		public void Increase(int count) {
			_state.Coins += count;
		}
	}
}