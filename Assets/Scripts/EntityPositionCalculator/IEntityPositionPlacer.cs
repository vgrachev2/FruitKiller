
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EntityPositionCalculator
{
    public interface IEntityPositionPlacer
    {
        IEnumerable<EntityPositionInfo> GeneratePositions(IEntityFactory factory,EntityPositionPlacerProperties properties);
    }
}
