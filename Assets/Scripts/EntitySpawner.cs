using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Entity;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts
{
    public class EntitySpawner:MonoBehaviour, IEntitySpawner
    {
        [Dependency]
        public IEntityFactory EntityFactory { private get; set; }

        public float spawnTime = 5f;		
        public float spawnDelay = 3f;	
		private Vector3 _vector;

        public void Start(Vector3 vector)
        {
			_vector = vector;
			for (int i=0; i<5; i++) {
				var createdObject=EntityFactory.CreateRandomObject(vector);
			    var entityScript=createdObject.GetComponent<Entity.Entity>();
			    entityScript.EntitySpawner = this;
			}
		
        }

        public void Spawn()
        {
			var createdObject=EntityFactory.CreateRandomObject(_vector);
			var entityScript=createdObject.GetComponent<Entity.Entity>();
			entityScript.EntitySpawner = this;
        }
    }
}
