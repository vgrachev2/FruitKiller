using UnityEngine;

namespace Assets.Scripts
{
    public interface IEntityPlacer
    {
        void PlaceEntity(Vector3 BoundaryCenterCoordinate, Vector3 BoundaryScale, Vector3 EntityDistance, Vector3 EntityScale);
        void CreateEntities();
    }
}