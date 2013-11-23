using System.Collections.Generic;
using Assets.Scripts.EntityPositionCalculator;
using UnityDI;
using UnityEngine;
using Assets.Scripts.EntityPositionCalculator.Generators;

namespace Assets.Scripts
{
    public class EntityPlacer: IEntityPlacer
    {
        [Dependency]
		public IEntityPositionGenerator PositionGenerator { private get; set; }

        [Dependency]
        public IEntityFactory EntityFactory { private get; set; }

		public Vector3 BoundaryCenterCoordinate;
		public Vector3 BoundaryScale;
		public Vector3 EntityDistance;
		public Vector3  EntityScale;

        public string EntityTagName;

		public void PlaceEntity() {

			if (PositionGenerator == null)
			{
				Debug.Log("В скрипте, размещающий объекты по сцене не задан генератор позиции");

			}

            PositionGenerator.GeneratePositions(
                    EntityFactory,
                    new EntityGeneratorProperties() {
				        BoundaryCenterCoordinate = BoundaryCenterCoordinate,
                        BoundaryScale = BoundaryScale,
				        EntityDistance = EntityDistance,
                        EntityScale = EntityScale
                    });

		}


        
    }
}
