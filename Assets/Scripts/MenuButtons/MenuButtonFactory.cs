using System;
using System.Xml.Schema;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.MenuButtons
{
	public class MenuButtonFactory : MonoBehaviour, IMenuButtonFactory
	{
		[Dependency]
		public IDIContainer DIContainer { private get; set; }

		public void BuildButton(Action action, string prefabName, Vector3 position,GameObject plane)
		{
			var prefab = Resources.Load(prefabName);
            var component = Instantiate(prefab, new Vector3(position.x, position.y, position.z), Quaternion.identity) as GameObject;
		    component.transform.parent = plane.transform;
			component.transform.localPosition = position;
			component.AddComponent<MenuButton>();
			var menuButton = component.GetComponent<MenuButton>();
            menuButton.Action = action;
			DIContainer.BuildUp(menuButton);
		}
	}
}