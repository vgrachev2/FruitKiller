using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.EntityPositionCalculator.Generators
{
    public class RectanglePositionGenerator:IEntityPositionGenerator
    {
        public IEnumerable<EntityPositionInfo> GeneratePositions(EntityFactory factory, EntityGeneratorProperties properties)
        {
            float startX = properties.BoundaryCenterCoordinate.x - (properties.BoundaryScale.x/2);
            float startY = properties.BoundaryCenterCoordinate.y + (properties.BoundaryScale.y/2);
            var startPosition = new Vector2(startX,startY);
           //Рассчитываем количество возможных объектов по x
            var numberForX=properties.BoundaryScale.x/(properties.EntityDistance.x + properties.EntityScale.x);
            var numberForY = properties.BoundaryScale.y / (properties.EntityDistance.y + properties.EntityScale.y);
            for (int i = 0; i < numberForY; i++)
            {
                for (int j = 0; j < numberForX; j++)
                {
                    factory.CreateRandomObject(new Vector3(startX+(properties.EntityDistance.x + properties.EntityScale.x) * j, startY-(properties.EntityDistance.y + properties.EntityScale.y)*i, 0));
                }
            }
          

			return null;
        }

    }
}
