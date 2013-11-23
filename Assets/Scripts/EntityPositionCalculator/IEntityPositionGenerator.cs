
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EntityPositionCalculator
{
    public interface IEntityPositionGenerator
    {
        IEnumerable<EntityPositionInfo> GeneratePositions(EntityFactory factory,EntityGeneratorProperties properties);
    }
}
