using System.Collections.Generic;
using Assets.Scripts.EntityPositionCalculator;
using UnityEngine;
using Assets.Scripts.EntityPositionCalculator.Generators;

namespace Assets.Scripts
{
    public class EntityPlacer:MonoBehaviour
    {

		public IEntityPositionGenerator PositionGenerator { private get; set; }
        public EntityFactory EntityFactory { get; set; }
		public Vector3 BoundaryCenterCoordinate;
		public Vector3 BoundaryScale;
		public Vector3 EntityDistance;
		public Vector3  EntityScale;

        public string EntityTagName;

		private void Start(){
			PositionGenerator = new RectanglePositionGenerator ();
			if (PositionGenerator == null)
			{
				Debug.Log("В скрипте, размещающий объекты по сцене не задан генератор позиции");

			}

            EntityFactory = new EntityFactory("Prefabs/Entities");
            PositionGenerator.GeneratePositions(EntityFactory,
                    new EntityGeneratorProperties()
                    {
				BoundaryCenterCoordinate = BoundaryCenterCoordinate,
                        BoundaryScale = BoundaryScale,
				EntityDistance = EntityDistance,
                        EntityScale = EntityScale
                        
                    });

		}


        
    }
}
