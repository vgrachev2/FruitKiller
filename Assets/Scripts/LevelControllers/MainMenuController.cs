using Assets.Scripts.Events;
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
            ButtonFactory.BuildButton(() =>  EventManager.instance.TriggerEvent(new HowToPlayButtonClicked()), 
                "Prefabs/Buttons/StartButton", new Vector3(0, -2, 0),plane);

            ButtonFactory.BuildButton(() => EventManager.instance.TriggerEvent(new PauseButtonClicked()), "Prefabs/Buttons/SettingsButton", new Vector3(4.622211f, -3.440617f, 0), plane);
		}

	  
	}
}
