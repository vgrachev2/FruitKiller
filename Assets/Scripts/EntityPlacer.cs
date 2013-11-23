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
                        BoundaryCenterCoordinate = new Vector3(0, 0, 0),
                        BoundaryScale = new Vector3(20, 20, 20),
                        EntityDistance = new Vector2(1,1),
                        EntityScale = new Vector3(1,1,0)
                        
                    });

		}


        
    }
}
