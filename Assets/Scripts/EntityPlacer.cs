using System.Collections.Generic;
using Assets.Scripts.EntityPositionCalculator;
using UnityEngine;

namespace Assets.Scripts
{
    public class EntityPlacer:MonoBehaviour
    {

		public IEntityPositionGenerator PositionGenerator { private get; set; }
        public EntityFactory EntityFactory { get; set; }

        public string EntityTagName;

		private void Start(){
			if (PositionGenerator == null)
			{
				Debug.Log("В скрипте, размещающий объекты по сцене не задан генератор позиции");
				return;
			}
            EntityFactory=new EntityFactory(GameObject.FindGameObjectsWithTag(EntityTagName));
			PlaceEntities(PositionGenerator.GeneratePositions(EntityFactory,
                new EntityGeneratorProperties()
                {
                    BoundaryCenterCoordinate = new Vector3(0,0,0),
                    BoundaryScale = new Vector3(10,10,10),
                    
                }));

		}


        private void PlaceEntities(IEnumerable<EntityPositionInfo> entitiesWithPosition)
        {
            foreach (var entity in entitiesWithPosition)
            {
                entity.Entity.transform.position = entity.EntityPosition;
            }
        }
    }
}
