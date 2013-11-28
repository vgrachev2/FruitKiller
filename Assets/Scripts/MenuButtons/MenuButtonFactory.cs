using System.Xml.Schema;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.MenuButtons
{
	public class MenuButtonFactory : MonoBehaviour, IMenuButtonFactory
	{
		[Dependency]
		public IDIContainer DIContainer { private get; set; }

		public void BuildButton(string levelName, string prefabName, Vector3 position)
		{
			var prefab = Resources.Load(prefabName);
			var component = Instantiate(prefab, new Vector3(position.x, position.y, position.z), Quaternion.identity) as GameObject;
			component.AddComponent<MenuButton>();
			var menuButton = component.GetComponent<MenuButton>();
			menuButton.LevelName = levelName;
			DIContainer.BuildUp(menuButton);
		}
	}
}