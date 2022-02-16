using Sample.State;

namespace Sample.Service {
	public sealed class CoinService {
		public int Coins => _state.Coins;

		readonly CoinState _state;
		readonly IAnalyticsService _analytics;
		readonly DebtService _debtService;

		public CoinService(CoinState state, IAnalyticsService analytics, DebtService debtService) {
			_state = state;
			_analytics = analytics;
			_debtService = debtService;
		}

		public bool IsEnough(int count) => Coins >= count || _debtService.AllowOverdraft;

		public void Consume(int count) {
			_state.Coins -= count;
			_analytics.SendEvent($"ConsumeCoins_{count}");
		}

		public void Increase(int count) {
			_state.Coins += count;
			_analytics.SendEvent($"IncreaseCoins_{count}");
		}
	}
}