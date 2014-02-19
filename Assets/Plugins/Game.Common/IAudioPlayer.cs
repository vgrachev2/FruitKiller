using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assets.Plugins.Game.Common
{
    public interface IAudioPlayer
    {
        void Play(string name);

        void PlayLoop(string name);

        void SetVolume(float volume);
    }
}
