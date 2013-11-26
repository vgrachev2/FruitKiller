using System.Collections.Generic;
using System.Linq;
using FruitKiller;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts {
	public class EntityFactory : MonoBehaviour, IEntityFactory {
		[Dependency]
		public IDIContainer DIContainer { private get; set; }

		private IEnumerable<Object> _notCreatedPrefabs;

		public EntityFactory(string pathToEntitiesPrefabs) {
			_notCreatedPrefabs = Resources.LoadAll(pathToEntitiesPrefabs);
		}

		public GameObject CreateRandomObject(Vector3 position) {
			int randomPrefabPosition = (int)Random.Range(0, _notCreatedPrefabs.Count());
			var entity = Instantiate(_notCreatedPrefabs.ElementAt(randomPrefabPosition), new Vector3(position.x, position.y, position.z), Quaternion.identity) as GameObject;
			var entityBehaivor = entity.GetComponent<Entity>();
			DIContainer.BuildUp(entityBehaivor);
			return entity;

		}

	    public GameObject CreateObject(Object prefab,Vector3 position)
	    {
            var entity = Instantiate(prefab, position, Quaternion.identity) as GameObject;
            var entityBehaivor = entity.GetComponent<Entity>();
            DIContainer.BuildUp(entityBehaivor);
            return entity;
	    }


        public GameObject GetRandomPrefab()
        {
            int randomPrefabPosition = (int)Random.Range(0, _notCreatedPrefabs.Count());
		
            return _notCreatedPrefabs.ElementAt(randomPrefabPosition) as GameObject;
        }
    }
}
