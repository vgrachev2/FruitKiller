using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public interface ICountdownTimer
    {
        void StartCountdown(float startTime, Action onFinish);

        void Update();

        void Stop();

        void Resume();

        void OnGUI();
    }
}
