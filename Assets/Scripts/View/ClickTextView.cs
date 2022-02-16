using Sample.Service;
using TMPro;
using UnityEngine;
using VContainer;

namespace Sample.View {
	[RequireComponent(typeof(TMP_Text))]
	public sealed class ClickTextView : MonoBehaviour {
		[SerializeField] TMP_Text _text;

		ClickService _clickService;

		[Inject]
		public void Init(ClickService clickService) {
			_clickService = clickService;
			UpdateState();
		}

		void Reset() =>
			_text = GetComponent<TMP_Text>();

		public void UpdateState() =>
			_text.text = $"Clicks: {_clickService.ClickCount}";
	}
}