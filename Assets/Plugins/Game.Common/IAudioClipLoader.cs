using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Plugins.Game.Common
{
    public interface IAudioClipLoader
    {
        AudioClip Load(string name);
    }
}
