using System;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public class ScorePrinter: IScorePrinter
    {
        [UnityDI.Dependency]
        public IScoreManager ScoreManager { private get; set; }

        public void Print(Vector3 correctScorePlace, Vector3 incorrectScorePlace)
        {
			var correctScore = Camera.main.WorldToScreenPoint (correctScorePlace);
			var incorrectScore = Camera.main.WorldToScreenPoint (incorrectScorePlace);
			var guiStyle = new GUIStyle ();
			guiStyle.fontSize = 20;
			guiStyle.normal.textColor = new Color (0, 0.7f, 0);
			GUI.Label (new Rect (correctScore.x, Screen.height-correctScore.y, 20, 20), ScoreManager.Correct.ToString(),guiStyle);
			guiStyle.normal.textColor = Color.red;
			GUI.Label (new Rect (incorrectScore.x, Screen.height-incorrectScore.y, 20, 20), ScoreManager.Incorrect.ToString (),guiStyle);
		}
    }
}
