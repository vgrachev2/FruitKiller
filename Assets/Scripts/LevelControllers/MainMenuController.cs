using Assets.Scripts.MenuButtons;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.LevelControllers {
	public class MainMenuController : MonoBehaviour
	{
		[Dependency]
		public IMenuButtonFactory ButtonFactory { private get; set; }

		public void BildStartButton(GameObject plane)
		{
			ButtonFactory.BuildButton(() => Application.LoadLevel("MakeChoiseCharacter"), "Prefabs/Buttons/StartButton", new Vector3(0, -2, -5),plane);
		}
	}
}
