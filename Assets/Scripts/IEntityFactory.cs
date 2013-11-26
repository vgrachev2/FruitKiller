using UnityEngine;

namespace Assets.Scripts
{
    public interface IEntityFactory
    {
        GameObject CreateObject(Object prefab, Vector3 position);
        GameObject CreateRandomObject(Vector3 position);
        GameObject GetRandomPrefab();
    }
}