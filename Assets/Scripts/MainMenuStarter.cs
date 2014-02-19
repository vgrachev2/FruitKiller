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
          
          
		}

		public void OnGUI()
		{
          
	    }
        
	}
}
