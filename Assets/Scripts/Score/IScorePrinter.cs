using UnityEngine;

namespace Assets.Scripts.Score
{
    public interface IScorePrinter
    {
        void Print();
        void SetPlaceForPrint(GUIText guiText);
    }
}