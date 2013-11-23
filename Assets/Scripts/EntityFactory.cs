using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FruitKiller;
using UnityEngine;

namespace Assets.Scripts
{
    public class EntityFactory:MonoBehaviour
    {
        private IEnumerable<GameObject> _entities;

        public EntityFactory(IEnumerable<GameObject> entities)
        {
            _entities = entities;
        }

        public GameObject CreateRandomObject()
        {
            return null;
        }
    }
}
