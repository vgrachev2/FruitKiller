using UnityEngine;

namespace Assets.Scripts
{
    public interface IEntitySpawner
    {
        void Start(Vector3 vector);
        void Spawn();
    }
}