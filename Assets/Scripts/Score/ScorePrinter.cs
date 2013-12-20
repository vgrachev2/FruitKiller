using System;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public class ScorePrinter:MonoBehaviour, IScorePrinter
    {
        [UnityDI.Dependency]
        public IScoreManager ScoreManager { private get; set; }

        private GUIText _guiText;

        public void Print()
        {
            if (ScoreManager != null)
            {
				if(_guiText!=null){
                 _guiText.text = "Score: " + ScoreManager.Score;
				}
            }
             
        }

        public void SetPlaceForPrint(GUIText guiText)
        {
            _guiText = guiText;
        }
    }
}
