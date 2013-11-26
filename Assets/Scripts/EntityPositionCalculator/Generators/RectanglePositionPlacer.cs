﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.EntityPositionCalculator.Generators
{
    public class RectanglePositionPlacer : IEntityPositionPlacer
    {
        public IEnumerable<EntityPositionInfo> GeneratePositions(IEntityFactory factory, EntityPositionPlacerProperties properties)
        {
            var entityPositionsInfoes = new List<EntityPositionInfo>();
            float startX = properties.BoundaryCenterCoordinate.x - (properties.BoundaryScale.x / 2)+properties.EntityDistance.x/2;
            float startY = properties.BoundaryCenterCoordinate.y + (properties.BoundaryScale.y / 2) - properties.EntityDistance.y / 2;
            var startPosition = new Vector2(startX, startY);
            //Рассчитываем количество возможных объектов по x
            var numberForX = properties.BoundaryScale.x / (properties.EntityDistance.x + properties.EntityScale.x);
            var numberForY = properties.BoundaryScale.y / (properties.EntityDistance.y + properties.EntityScale.y);
            for (int i = 0; i < numberForY; i++)
            {
                for (int j = 0; j < numberForX; j++)
                {
                    entityPositionsInfoes.Add(new EntityPositionInfo() { EntityPosition = new Vector3(startX + (properties.EntityDistance.x + properties.EntityScale.x) * j, startY - (properties.EntityDistance.y + properties.EntityScale.y) * i, 0),Entity = factory.GetRandomPrefab()});
                }
            }


            return entityPositionsInfoes;
        }

    }
}
