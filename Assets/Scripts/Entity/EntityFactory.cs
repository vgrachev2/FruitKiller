using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Base;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Entity {
	public class EntityFactory : MonoBehaviour, IEntityFactory {
		[Dependency]
		public IDIContainer DIContainer { private get; set; }

		private readonly IEnumerable<Object> _notCreatedPrefabs;

		public EntityFactory(string pathToEntitiesPrefabs) {
			_notCreatedPrefabs = Resources.LoadAll(pathToEntitiesPrefabs);
		}

		public GameObject CreateRandomObject(Vector3 position) {
			var randomPrefabPosition = (int)Random.Range(0, _notCreatedPrefabs.Count());
		    var prefab = _notCreatedPrefabs.ElementAt(randomPrefabPosition);
			return CreateObject(prefab, position);

		}

	    public GameObject CreateObject(Object prefab, Vector3 position)
	    {
            var entity = Instantiate(prefab, position, Quaternion.identity) as GameObject;
            var entityBehaivor = entity.GetComponent<Scripts.Entity.Entity>();
            DIContainer.BuildUp(entityBehaivor);
            return entity;
	    }


        public GameObject GetRandomPrefab()
        {
            var randomPrefabPosition = (int)Random.Range(0, _notCreatedPrefabs.Count());
            return _notCreatedPrefabs.ElementAt(randomPrefabPosition) as GameObject;
        }
    }
}
