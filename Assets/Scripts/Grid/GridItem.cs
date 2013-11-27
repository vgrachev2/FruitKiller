using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class GridItem
    {
        private Vector3 _position;
        private GameObject _entity;

        public GridItem(Vector3 position, GameObject entity)
        {
            _position = position;
            _entity = entity;
        }

        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public GameObject Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
    }
}
