using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.EventHandlers.Entities;
using Assets.Scripts.Events;
using Assets.Scripts.MenuButtons;
using Assets.Scripts.Score;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.EventHandlers.Popups
{
    public class ShowPausePopup: EventHandlerBase<PauseButtonClicked>
    {
        [Dependency]
        public IMenuButtonFactory _menuButtonFactory { get; set; }

        [Dependency]
        public IDIContainer DIContainer { private get; set; }

        [Dependency]
        public ICountdownTimer _countdownTimer { get; set; }

        public override void HandleEvent(PauseButtonClicked evt)
        {
            _countdownTimer.Stop();

            var prefab = Resources.Load("Prefabs/PausePopup");
            var popup = Instantiate(prefab, new Vector3(0, 0, -8), Quaternion.identity) as GameObject;
            var soundSlder = popup.GetComponent<SoundSlider>();
            DIContainer.BuildUp(soundSlder);

            _menuButtonFactory.BuildButton(() =>
            {
                _countdownTimer.Resume();
                Destroy(popup);
            }, "Prefabs/Buttons/ResumeGame", new Vector3(0, 0.6538755f, 0), popup);
            _menuButtonFactory.BuildButton(() => Application.LoadLevel("MainMenuScene"), "Prefabs/Buttons/BackToMenu", new Vector3(0, -0.4939326f, 0), popup);
            _menuButtonFactory.BuildButton(() =>
            {
                Destroy(popup);
                _countdownTimer.Resume();
            }, "Prefabs/Buttons/ExitButton", new Vector3(3.079204f, 2.25636f, 0f), popup);
        }
    }
}
