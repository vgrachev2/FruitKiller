using Assets.Scripts.MenuButtons;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.LevelControllers {
	public class MainMenuController : MonoBehaviour
	{
		[Dependency]
		public IMenuButtonFactory ButtonFactory { private get; set; }

		public void BildStartButton()
		{
			ButtonFactory.BuildButton("GameScene", "Prefabs/Buttons/StartButton", new Vector3(0, 0, 0));
		}
	}
}
