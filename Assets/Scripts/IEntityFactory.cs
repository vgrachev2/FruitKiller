using UnityEngine;

namespace Assets.Scripts
{
    public interface IEntityFactory
    {
        GameObject CreateRandomObject(Vector3 position);
    }
}