using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Sample.View {
	[RequireComponent(typeof(Button))]
	public sealed class UpgradeButtonView : MonoBehaviour {
		[SerializeField] Button _button;

		UpgradeWindow _window;

		[Inject]
		public void Init(UpgradeWindow window) {
			_window = window;
		}

		void Awake() {
			_button.onClick.AddListener(Click);
		}

		void Reset() {
			_button = GetComponent<Button>();
		}

		void Click() {
			_window.Show();
		}
	}
}