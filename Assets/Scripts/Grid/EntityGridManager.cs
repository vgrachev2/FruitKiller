using Assets.Scripts.Entity;
using Assets.Scripts.Grid.EntityPositionCalculator;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class EntityGridManager:MonoBehaviour,IEntityGridManager
    {
        [Dependency]
		public IEntityGridCreator GridCreator { private get; set; }

        [Dependency]
        public IEntityFactory EntityFactory { private get; set; }

        private EntityGrid _grid;

        public string EntityTagName;
         
        public void InitializationGrid(Vector3 boundaryCenterCoordinate, Vector3 boundaryScale, Vector3 entityDistance, Vector3 entityScale)
        {

            if (GridCreator == null)
			{
				Debug.Log("В скрипте, размещающий объекты по сцене не задан генератор позиции");

			}
            _grid = GridCreator.EntityGridCreate(new EntityPositionPlacerProperties()
            {
				        BoundaryCenterCoordinate = boundaryCenterCoordinate,
                        BoundaryScale = boundaryScale,
				        EntityDistance = entityDistance,
                        EntityScale = entityScale
                    });
                 

		}

      

        public void InitializationEntitiesInGrid()
        {
            if (_grid == null)
            {
                return;
            }
            var randomEmptyGridItem = _grid.GetRandomElementByState(GridItemState.NotInitilization);
            if (randomEmptyGridItem != null) {
				randomEmptyGridItem.Entity=EntityFactory.CreateObject (EntityFactory.GetRandomPrefab(), randomEmptyGridItem.Position);
			}
        }

        public void RecreateDestroyedEntity()
        {
            if(_grid==null)return;
            var randomDestroyedGridItem = _grid.GetRandomElementByState(GridItemState.Deleted);
            if (randomDestroyedGridItem!=null)
            {
                randomDestroyedGridItem.Entity = EntityFactory.CreateObject(EntityFactory.GetRandomPrefab(),
                    randomDestroyedGridItem.Position);
            }
        }
       
       
    }
}
