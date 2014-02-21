using Assets.Plugins.Game.Common;
using Assets.Scripts.LevelControllers;
using UnityEngine;

namespace Assets.Scripts {
	public class MainMenuStarter : MonoBehaviour
	{
	    public GameObject MenuPlaneLocal;
	

		public void Start()
		{
			var container = ContainerSingletone.Container;
			var controller = container.Resolve<MainMenuController>();
			controller.BildStartButton(MenuPlaneLocal);
			var audioPlayer = container.Resolve<IAudioPlayer>();
			audioPlayer.PlayLoop("MainTheme");
          
		}

		public void OnGUI()
		{
          
	    }
        
	}
}
