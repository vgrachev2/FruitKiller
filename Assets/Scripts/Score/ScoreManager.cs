using Assets.Scripts.Score.ScorePlane;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public class ScoreManager:IScoreManager
    {
        private int _score;

        public IScorePlaneManipulator ScoreManipulator { get; set; }

        public ScoreManager()
        {
            _score = 0;
            Correct = 0;
            Incorrect = 0;
        }

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        public int Correct { get; set; }

        public int Incorrect { get; set; }


        public void PlusValueToScore(int value)
        {
            _score += value;
            Correct++;
            // ScoreManipulator.AddNewPlaneItem();

        }

        public void MinusValueToScore(int value)
        {
            _score -= value;
            Incorrect++;
        }
    }

}
