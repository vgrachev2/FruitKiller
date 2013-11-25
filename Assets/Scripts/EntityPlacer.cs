using System.Collections.Generic;
using Assets.Scripts.EntityPositionCalculator;
using UnityDI;
using UnityEngine;
using Assets.Scripts.EntityPositionCalculator.Generators;

namespace Assets.Scripts
{
    public class EntityPlacer:IEntityPlacer
    {
        [Dependency]
		public IEntityPositionPlacer PositionGenerator { private get; set; }

        [Dependency]
        public IEntityFactory EntityFactory { private get; set; }


        public string EntityTagName;

        public void PlaceEntity(Vector3 boundaryCenterCoordinate, Vector3 boundaryScale, Vector3 entityDistance, Vector3 entityScale)
        {

			if (PositionGenerator == null)
			{
				Debug.Log("В скрипте, размещающий объекты по сцене не задан генератор позиции");

			}

            PositionGenerator.GeneratePositions(
                    EntityFactory,
                    new EntityPositionPlacerProperties() {
				        BoundaryCenterCoordinate = boundaryCenterCoordinate,
                        BoundaryScale = boundaryScale,
				        EntityDistance = entityDistance,
                        EntityScale = entityScale
                    });

		}

    }
}
