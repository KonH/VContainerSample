using System;
using Sample.Service;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Sample.View {
	[RequireComponent(typeof(Button))]
	public sealed class ClickButtonView : MonoBehaviour {
		[SerializeField] Button _button;
		[SerializeField] ClickTextView _text;

		ClickService _clickService;
		Func<int, ClickEffectView> _viewFactory;

		[Inject]
		public void Init(ClickService clickService, Func<int, ClickEffectView> viewFactory) {
			_clickService = clickService;
			_viewFactory = viewFactory;
		}

		void Awake() {
			_button.onClick.AddListener(Click);
		}

		void Reset() {
			_button = GetComponent<Button>();
			_text = GetComponentInChildren<ClickTextView>();
		}

		void Update() =>
			_button.interactable = _clickService.CanClick;

		void Click() {
			_clickService.Click();
			_viewFactory(_clickService.ClickCount);
			_text.UpdateState();
		}
	}
}