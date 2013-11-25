using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.EntityPositionCalculator
{
    public class EntityPositionPlacerProperties
    {
        public Vector3 BoundaryCenterCoordinate { get; set; }
        public Vector3 BoundaryScale { get; set; }
        public Vector3 EntityScale { get; set; }
        public Vector2 EntityDistance { get; set; }
    }
}
