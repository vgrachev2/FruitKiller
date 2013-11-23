using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.EntityPositionCalculator
{
    public class EntityPositionInfo
    {
        private Vector3 _entityPosition;
        private GameObject _entity;

        public Vector3 EntityPosition
        {
            get { return _entityPosition; }
            set { _entityPosition = value; }
        }

        public GameObject Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
    }
}
