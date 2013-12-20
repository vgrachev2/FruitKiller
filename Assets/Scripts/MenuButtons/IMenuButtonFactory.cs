using System;
using UnityEngine;

namespace Assets.Scripts.MenuButtons
{
	public interface IMenuButtonFactory
	{
		void BuildButton(Action action, string prefabName, Vector3 position,GameObject plane);
	}
}