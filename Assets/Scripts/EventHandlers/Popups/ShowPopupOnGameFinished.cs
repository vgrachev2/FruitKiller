using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.EventHandlers.Entities;
using Assets.Scripts.Events;
using Assets.Scripts.Events.Entities;
using Assets.Scripts.MenuButtons;
using Assets.Scripts.Score;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.EventHandlers.Popups
{
    public class ShowPopupOnGameFinished : EventHandlerBase<GameFinished>
    {
         [Dependency]
        public IMenuButtonFactory _menuButtonFactory { get; set; }

         [Dependency]
         public IDIContainer DIContainer { private get; set; }

		[UnityDI.Dependency]
		public IScoreManager ScoreManager { private get; set; }

         public override void HandleEvent(GameFinished evt)
        {
            var prefab = Resources.Load("Prefabs/FinishMenu");
            var popup = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
             var scorePrinter=popup.GetComponent<ScorePrinter>();
			DIContainer.BuildUp (scorePrinter);
             scorePrinter.Print();
	 
            _menuButtonFactory.BuildButton(() => Application.LoadLevel("MainMenuScene"), "Prefabs/Buttons/BackToMenu", new Vector3(0, -0.7707841f, 0), popup);
            _menuButtonFactory.BuildButton(() => Application.LoadLevel("GameScene"), "Prefabs/Buttons/Restart", new Vector3(0, -1.575618f, 0), popup);
        }
    }
}
