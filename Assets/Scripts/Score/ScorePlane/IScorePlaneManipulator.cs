using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Score.ScorePlane
{
    public interface IScorePlaneManipulator
    {
        void Create();
        void DeleteFirstPlaneItem();
        void AddNewPlaneItem();
        GameObject WorkPlane { get; set; }
    }
}
