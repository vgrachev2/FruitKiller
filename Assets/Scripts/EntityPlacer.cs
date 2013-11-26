using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.EntityPositionCalculator;
using FruitKiller;
using UnityDI;
using UnityEngine;
using Assets.Scripts.EntityPositionCalculator.Generators;

namespace Assets.Scripts
{
    public class EntityPlacer:MonoBehaviour,IEntityPlacer
    {
        [Dependency]
		public IEntityPositionPlacer PositionGenerator { private get; set; }

        [Dependency]
        public IEntityFactory EntityFactory { private get; set; }

        private IEnumerable<EntityPositionInfo> _entityPositionInfos; 

        public string EntityTagName;

        public void PlaceEntity(Vector3 boundaryCenterCoordinate, Vector3 boundaryScale, Vector3 entityDistance, Vector3 entityScale)
        {

			if (PositionGenerator == null)
			{
				Debug.Log("В скрипте, размещающий объекты по сцене не задан генератор позиции");

			}

            _entityPositionInfos = PositionGenerator.GeneratePositions(
                    EntityFactory,
                    new EntityPositionPlacerProperties() {
				        BoundaryCenterCoordinate = boundaryCenterCoordinate,
                        BoundaryScale = boundaryScale,
				        EntityDistance = entityDistance,
                        EntityScale = entityScale
                    });

		}

        public void CreateEntities()
        {
            if (_entityPositionInfos == null)
            {
                return;
            }
            var entityPositions=_entityPositionInfos.Where(x => x.Entity.activeInHierarchy!=true);
            var entityPosition=GetRandomElementFromCollection(entityPositions);
            if (entityPosition != null) {
				entityPosition.Entity=EntityFactory.CreateObject (entityPosition.Entity, entityPosition.EntityPosition);
			}
        }

        private EntityPositionInfo  GetRandomElementFromCollection(IEnumerable<EntityPositionInfo> entityPositions)
        {if (entityPositions.Count () == 0) {
				return null;
			}
            int randomPrefabPositionIndex = (int)Random.Range(0, entityPositions.Count());
            return entityPositions.ElementAt(randomPrefabPositionIndex);
        }
        

    }
}
