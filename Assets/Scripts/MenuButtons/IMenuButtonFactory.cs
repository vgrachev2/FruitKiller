using UnityEngine;

namespace Assets.Scripts.MenuButtons
{
	public interface IMenuButtonFactory
	{
		void BuildButton(string levelName, string prefabName, Vector3 position);
	}
}