using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Score
{
    public class ScoreManager:IScoreManager
    {
        private int _score;

        public ScoreManager()
        {
            _score = 0;
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


        public void PlusValueToScore(int value)
        {
            _score += value;
        }

        public void MinusValueToScore(int value)
        {
            _score -= value;
        }
    }

    
}
