using FruitKiller.Base;
using Game.Common;
using UnityDI;
using UnityEngine;

namespace FruitKiller
{
    public class Entity : MonoBehaviour
    {
        
        public bool Edible;
       
        public string Name;

        [Dependency]
        public ITouchConroller Conroller  { private get; set; }

        // Use this for initialization
        void Start()
        {

        }

        
        // Update is called once per frame
        void Update()
        {
            if (Conroller != null)
            {
                if (Conroller.Touched(this.gameObject))
                {
                    Debug.Log("touch");
                }
            }
        }
    }
}

