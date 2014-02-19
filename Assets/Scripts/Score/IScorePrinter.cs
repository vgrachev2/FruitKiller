using UnityEngine;

namespace Assets.Scripts.Score
{
    public interface IScorePrinter
    {
        GameObject CorrectScorePlace { get; set; }
        GameObject IncorrectScorePlace { get; set; }
        int FontSize { get; set; }
        void Print();
    }
}