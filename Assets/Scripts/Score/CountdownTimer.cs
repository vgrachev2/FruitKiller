using System;
using System.Runtime.InteropServices;
using Assets.Scripts.MenuButtons;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public class CountdownTimer : ICountdownTimer
    {
        private float _timer = 0.0f;
        private float _startTime = 120.0f;
        private bool _showTimer = false;
        private Action _onFinish;
        [Dependency]
        public IProgressBar ProgressBar { private get; set; }

        public void StartCountdown(float startTime, Action onFinish)
        {

            _startTime = startTime;
            _timer = startTime;
            _showTimer = true;
            _onFinish = onFinish;
        }
         
        public void Update() 
        {
            if (_showTimer)
            {
				if(_timer==0){
					return;
				}
                ProgressBar.Update(_timer/30);
                _timer -= Time.deltaTime;

				if (_timer < 10)
                {
                    Debug.Log("TEN SECONDS LEFT !");
                }


                if (_timer <= 0)
                {
                    Debug.Log("OUT OF TIME");
                    _timer = 0;
                    _onFinish();
                }
            }
        }

        public void OnGUI() 
        {
            GUI.Label(new Rect(10, 10, 150, 20), String.Format("{0:00}:{1:00}", _timer / 60.0, _timer % 60.0));
            ProgressBar.OnGui();
            
        }
    }
}