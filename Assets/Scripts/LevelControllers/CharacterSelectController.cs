﻿using Assets.Plugins.Game.Common;
using Assets.Scripts.Events;
using Assets.Scripts.MenuButtons;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.LevelControllers {
    public class CharacterSelectController : MonoBehaviour
	{
		[Dependency]
		public IMenuButtonFactory ButtonFactory { private get; set; }

        [Dependency]
        public IAudioPlayer Player { private get; set; }

        public CharacterSelectController()
        {
           
        }

        public void PlayMusic(){
            Player.PlayLoop("MainTheme");
        }

        public void BuildBackButton(GameObject plane){
            ButtonFactory.BuildButton(() => Application.LoadLevel("MainMenuScene"), "Prefabs/Buttons/Back", new Vector3(-4.401267f, 2.94901f, 0), plane);
        }

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

            ButtonFactory.BuildButton(() =>
            {
                PlayerPrefs.SetString("ChoisedCharacter", "Cat");
                PlayerPrefs.Save();
                Application.LoadLevel("GameScene");
            }, "Prefabs/characters/Cat", new Vector3(-0.3894792f, 0.5552426f, 0), plane);
		}
	}
}
