using Game.Common;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class GridItem
    {
        private Vector3 _position;
        private GameObject _entity;
        private GridItemState _state=GridItemState.NotInitilization;

        [Dependency]
        public ITouchConroller Conroller { private get; set; }


        public GridItem(Vector3 position)
        {
            _position = position;

        }

        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public GameObject Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
                if (value != null)
                {
                    _state=GridItemState.Created;
                }
            }
        }

        public GridItemState State
        {
            get
            {
				if (_state == GridItemState.Created && Entity == null)
				{
					_state = GridItemState.Deleted;
				}
                return _state;
            }
            set
            {
                _state = value;
            }
        }

    }
}
