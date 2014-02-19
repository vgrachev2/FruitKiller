using System;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public class ScorePrinter:MonoBehaviour,IScorePrinter
    {
        [UnityDI.Dependency]
        public IScoreManager ScoreManager {get; set; }

        public GameObject correctScorePlace;
        public GameObject incorrectScorePlace;
        public int fontSize;
      


		public void Print()
		{
		    OnGUI();
		}

		public void Update(){
			Print ();
		}

        public GameObject CorrectScorePlace
        {
            get
            {
                return correctScorePlace;
            }
            set
            {
                correctScorePlace = value;
            }
        }

        public int FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
            }
        }
		public void OnGUI(){
			var correctScore = Camera.main.WorldToScreenPoint (CorrectScorePlace.transform.position);
			var incorrectScore = Camera.main.WorldToScreenPoint (IncorrectScorePlace.transform.position);
			var guiStyle = new GUIStyle ();
            guiStyle.fontSize = fontSize;
			guiStyle.normal.textColor = new Color (0, 0.7f, 0);
			GUI.Label (new Rect (correctScore.x, Screen.height - correctScore.y, 20, 20), ScoreManager.Correct.ToString (), guiStyle);
			guiStyle.normal.textColor = Color.red;
			GUI.Label (new Rect (incorrectScore.x, Screen.height - incorrectScore.y, 20, 20), ScoreManager.Incorrect.ToString (), guiStyle);
		}

        public GameObject IncorrectScorePlace
        {
            get
            {
                return incorrectScorePlace;
            }
            set
            {
                incorrectScorePlace = value;
            }
        }
    }
}
