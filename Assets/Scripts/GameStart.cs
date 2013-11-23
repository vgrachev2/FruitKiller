using UnityDI;
using UnityEngine;

namespace TestDI.Demo {
	/// <summary>
	/// Класс, запускающий игру
	/// </summary>
	public class GameStarter : MonoBehaviour {
		private Container _container;

		public void Start() {
			SetupContainer();
		}

		public void Update() {
		}

		private void SetupContainer() {
			_container = new UnityDI.Container();
		}
	}
}
