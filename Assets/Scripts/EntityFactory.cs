using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class EntityFactory:MonoBehaviour
    {
        private IEnumerable<Object> _notCreatedPrefabs;

        public EntityFactory(string pathToEntitiesPrefabs)
        {
           _notCreatedPrefabs=Resources.LoadAll(pathToEntitiesPrefabs);
        }

        public GameObject CreateRandomObject(Vector3 position)
        {
            int randomPrefabPosition = (int)Random.Range(0, _notCreatedPrefabs.Count());
            return (GameObject)Instantiate(_notCreatedPrefabs.ElementAt(randomPrefabPosition), new Vector3(position.x, position.y, position.z), Quaternion.identity);

        }
    }
}
