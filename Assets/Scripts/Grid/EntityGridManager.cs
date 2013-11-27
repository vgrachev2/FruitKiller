using Assets.Scripts.Entity;
using Assets.Scripts.Grid.EntityPositionCalculator;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class EntityGridManager:MonoBehaviour,IEntityGridManager
    {
        [Dependency]
		public IEntityGridCreator GridGenerator { private get; set; }

        [Dependency]
        public IEntityFactory EntityFactory { private get; set; }

        private EntityGrid _grid;

        public string EntityTagName;
         
        public void InitializationGrid(Vector3 boundaryCenterCoordinate, Vector3 boundaryScale, Vector3 entityDistance, Vector3 entityScale)
        {

            if (GridGenerator == null)
			{
				Debug.Log("В скрипте, размещающий объекты по сцене не задан генератор позиции");

			}
            _grid = GridGenerator.EntityGridCreate(EntityFactory, new EntityPositionPlacerProperties()
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
            var randomEmptyGridItem = _grid.GetRandomEmptyElement();
            if (randomEmptyGridItem != null) {
				randomEmptyGridItem.Entity=EntityFactory.CreateObject (randomEmptyGridItem.Entity, randomEmptyGridItem.Position);
			}
        }

       
       
    }
}
