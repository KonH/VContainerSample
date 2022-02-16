using Sample.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Sample.View {
	public sealed class UpgradeWindow : MonoBehaviour {
		[SerializeField] Button _closeButton;
		[SerializeField] Button _upgradeButton;
		[SerializeField] TMP_Text _upgradePrice;

		UpgradeService _upgradeService;

		void Awake() {
			_upgradeButton.onClick.AddListener(Upgrade);
			_closeButton.onClick.AddListener(Hide);
			Hide();
		}

		[Inject]
		void Init(UpgradeService upgradeService) {
			_upgradeService = upgradeService;
		}

		void Hide() {
			gameObject.SetActive(false);
		}

		public void Show() {
			_upgradePrice.text = _upgradeService.UpgradePrice.ToString();
			_upgradeButton.interactable = _upgradeService.CanUpgrade();
			gameObject.SetActive(true);
		}

		void Upgrade() {
			_upgradeService.Upgrade();
			Hide();
		}
	}
}