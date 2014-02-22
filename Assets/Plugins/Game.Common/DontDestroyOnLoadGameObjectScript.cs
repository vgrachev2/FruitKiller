using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Plugins.Game.Common
{
   public class DontDestroyOnLoadGameObjectScript:MonoBehaviour
    {
       public void Start(){
           DontDestroyOnLoad(this.gameObject);
       }
    }
}
