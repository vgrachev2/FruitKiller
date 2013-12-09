using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Score.ScorePlane
{
    public class ScorePlaneItem:MonoBehaviour
    {
        public bool IsDeleted { get; set; }
        public int Index { get; set; }

		public void Destroy()
		{
		    IsDeleted = true;
			Destroy (this.transform.gameObject);
		}
    }
}
