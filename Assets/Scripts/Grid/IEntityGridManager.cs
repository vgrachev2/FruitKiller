using UnityEngine;

namespace Assets.Scripts.Grid
{
    public interface IEntityGridManager
    {
        void InitializationGrid(Vector3 boundaryCenterCoordinate, Vector3 boundaryScale, Vector3 entityDistance, Vector3 entityScale);
        void InitializationEntitiesInGrid();
        void RecreateDestroyedEntity();
    }
}