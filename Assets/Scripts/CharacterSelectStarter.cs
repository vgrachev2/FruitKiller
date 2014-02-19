using Assets.Scripts.LevelControllers;
using UnityEngine;

namespace Assets.Scripts {
    public class CharacterSelectStarter : MonoBehaviour
	{
	    public GameObject MenuPlaneLocal;

		public void Start()
		{
			var container = ContainerSingletone.Container;
			var controller = container.Resolve<CharacterSelectController>();
			controller.BildCharacter(MenuPlaneLocal);
		}
	}
}
