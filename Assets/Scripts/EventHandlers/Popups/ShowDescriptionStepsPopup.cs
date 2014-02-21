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
    public class ShowDescriptionStepsPopup : EventHandlerBase<HowToPlayButtonClicked>
    {
        [Dependency]
        public IMenuButtonFactory _menuButtonFactory { get; set; }

        [Dependency]
        public IDIContainer DIContainer { private get; set; }

        public override void HandleEvent(HowToPlayButtonClicked evt)
        {

            var prefab = Resources.Load("Prefabs/DescriptionStepsPopup");
            var popup = Instantiate(prefab, new Vector3(0, 0, 2), Quaternion.identity) as GameObject;
            _menuButtonFactory.BuildButton(() =>
            {
                Destroy(popup);

            }, "Prefabs/Buttons/ExitButton", new Vector3(3.079204f, 2.25636f,0f ), popup);

            _menuButtonFactory.BuildButton(() => Application.LoadLevel("MakeChoiseCharacter"), "Prefabs/Buttons/GoGame", new Vector3(0.04272377f, -1.592054f, 0f), popup);
        }
    }
}
