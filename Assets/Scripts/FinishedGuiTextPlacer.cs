using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class FinishedGuiTextPlacer:MonoBehaviour
    {
       public Transform target; // drag the target object here
       public Rect rect = new Rect(0,0,300,100);
       public Vector3 offset =  new Vector3(0, 1.5f,0); // height above the target position

        void Update()
        {
            var point = Camera.main.WorldToScreenPoint(target.position + offset);
            rect.x = point.x;
            rect.y = point.y - rect.height; // bottom left corner set to the 3D point
            GUI.Label(rect, target.name); // display its name, or other string
        } 
    }
}
