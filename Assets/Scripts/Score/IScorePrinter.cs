using UnityEngine;

namespace Assets.Scripts.Score
{
    public interface IScorePrinter
    {
        void Print(Vector3 correctScorePlace, Vector3 incorrectScorePlace);
    }
}