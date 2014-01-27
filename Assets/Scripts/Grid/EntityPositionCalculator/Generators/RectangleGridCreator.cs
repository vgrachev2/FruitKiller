using Assets.Scripts.Entity;
using UnityEngine;

namespace Assets.Scripts.Grid.EntityPositionCalculator.Generators
{
    public class RectangleGridCreator: IEntityGridCreator
    {
        public EntityGrid EntityGridCreate(EntityPositionPlacerProperties properties)
        {
         
            float startX = properties.BoundaryCenterCoordinate.x - (properties.BoundaryScale.x / 2) + properties.EntityDistance.x / 2;
            float startY = properties.BoundaryCenterCoordinate.y + (properties.BoundaryScale.y / 2) - properties.EntityDistance.y / 2;
            var startPosition = new Vector2(startX, startY);
            //Рассчитываем количество возможных объектов по x
            var numberForX =(int)(properties.BoundaryScale.x / (properties.EntityDistance.x + properties.EntityScale.x));
            var numberForY =(int)(properties.BoundaryScale.y / (properties.EntityDistance.y + properties.EntityScale.y));
            var grid = new EntityGrid(numberForX,numberForY);
            for (int i = 0; i < numberForY; i++)
            {
                for (int j = 0; j < numberForX; j++)
                {
                    var entityPosition = new Vector3(
                        startX + (properties.EntityDistance.x + properties.EntityScale.x)*j,
                        startY - (properties.EntityDistance.y + properties.EntityScale.y)*i, 0);
                    grid.SetGridItem(j,i,new GridItem(position:entityPosition));
                }
            }
            return grid;
        }
    }
}
