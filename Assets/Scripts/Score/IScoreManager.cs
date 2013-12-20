using Assets.Scripts.Score.ScorePlane;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public interface IScoreManager
    {
       IScorePlaneManipulator ScoreManipulator { get; set; }
       int Score { get; set; }
       void PlusValueToScore(int value);
       void MinusValueToScore(int value);
      
    }
}