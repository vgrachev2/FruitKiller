using Assets.Scripts.LevelControllers;
using UnityEngine;

namespace Assets.Scripts {
	public class MainMenuStarter : MonoBehaviour {
		public void Start()
		{
			var container = new ContainerInstaller().Install();
			var controller = container.Resolve<MainMenuController>();
		}
	}
}
