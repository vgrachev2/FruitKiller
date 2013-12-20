using Assets.Scripts.MenuButtons;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.LevelControllers {
    public class CharacterSelectController : MonoBehaviour
	{
		[Dependency]
		public IMenuButtonFactory ButtonFactory { private get; set; }

		public void BildCharacter(GameObject plane)
		{
            //ButtonFactory.BuildButton(() =>
            //{
            //    PlayerPrefs.SetString("ChoisedCharacter", "Cat");
            //    PlayerPrefs.Save();
            //    Application.LoadLevel("GameScene");
            //}, "Prefabs/characters/Cat", new Vector3(0, -2, -5), plane);

            ButtonFactory.BuildButton(() =>
            {
                PlayerPrefs.SetString("ChoisedCharacter", "Dog");
                PlayerPrefs.Save();
                Application.LoadLevel("GameScene");
            }, "Prefabs/characters/Dog", new Vector3(0.704466f, -0.9775231f, 0), plane);
		}
	}
}
