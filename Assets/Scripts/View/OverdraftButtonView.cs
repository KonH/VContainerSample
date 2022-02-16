using Sample.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Sample.View {
	[RequireComponent(typeof(Button))]
	public sealed class OverdraftButtonView : MonoBehaviour {
		[SerializeField] Button _button;
		[SerializeField] TMP_Text _text;

		DebtService _service;

		void Reset() {
			_button = GetComponent<Button>();
			_text = GetComponentInChildren<TMP_Text>();
		}

		void Awake() {
			_button.onClick.AddListener(ChangeState);
		}

		[Inject]
		public void Init(DebtService service) {
			_service = service;
			UpdateState();
		}

		void UpdateState() {
			_text.text = _service.AllowOverdraft ? "Disable overdraft" : "Enable overdraft";
		}

		void ChangeState() {
			_service.AllowOverdraft = !_service.AllowOverdraft;
			UpdateState();
		}
	}
}