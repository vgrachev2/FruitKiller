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
                _guiText.text = "Score: " + ScoreManager.Score;
                Debug.Log("Вывел счет");
            }
             
        }

        public void SetPlaceForPrint(GUIText guiText)
        {
            _guiText = guiText;
        }
    }
}
