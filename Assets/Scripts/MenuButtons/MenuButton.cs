using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Common;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.MenuButtons {
	public class MenuButton : MonoBehaviour {
		[Dependency]
		public ITouchConroller Conroller { private get; set; }

		public string LevelName;

		void Update() {
			if (Conroller != null) {
				if (Conroller.Touched(this.gameObject)) {
					Application.LoadLevel(LevelName);
				}
			}
		}
	}
}
