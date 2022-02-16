using Sample.Service;
using TMPro;
using UnityEngine;
using VContainer;

namespace Sample.View {
	[RequireComponent(typeof(TMP_Text))]
	public sealed class CoinsView : MonoBehaviour {
		[SerializeField] TMP_Text _text;

		CoinService _service;

		void Reset() {
			_text = GetComponent<TMP_Text>();
		}

		[Inject]
		public void Init(CoinService service) {
			_service = service;
		}

		void Update() =>
			_text.text = _service.Coins.ToString();
	}
}