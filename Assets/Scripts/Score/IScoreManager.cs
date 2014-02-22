using Assets.Scripts.Score.ScorePlane;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public interface IScoreManager
    {
       IScorePlaneManipulator ScoreManipulator { get; set; }
       int Score { get; }
       int Correct { get; }
       int Incorrect { get; }
       void PlusValueToScore(int value);
       void MinusValueToScore(int value);
        void Clear();

    }
}