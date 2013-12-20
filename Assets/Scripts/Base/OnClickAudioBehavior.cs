using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Base
{
    public class OnClickAudioBehavior : AudioBehaviorBase
    {
        void Update()
        {
            if (Conroller != null) 
            {
                 if (Conroller.BeginTouched(this.gameObject))
                 {
                     AudioPlayer.Play(AudioName);
                 }
             }
          }
    }
}
