using System;
using Sample.Manager;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Sample.Starter {
	public sealed class EntryPointStarter : IStartable, IDisposable {
		EntryPointManager _manager;

		[Inject]
		public void Init(EntryPointManager manager) {
			_manager = manager;
			Debug.Log("EntryPointStarter: initialized on scene load");
		}

		public void Start() => _manager.Start();

		public void Dispose() {
			Debug.Log("EntryPointStarter: disposed on scene unload");
		}
	}
}