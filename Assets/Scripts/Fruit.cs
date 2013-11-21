using System.Collections;
using Assets.Scripts.Helpers;
using FruitKiller.Base;
using UnityEngine;

namespace FruitKiller
{
    public class Fruit : MonoBehaviour,IEdible
    {
        [HideInInspector]
        [SerializeField]
        bool _edible;

        [HideInInspector] 
        [SerializeField] 
        private string _name;
       
        // Use this for initialization
        void Start()
        {

        }

        
        // Update is called once per frame
        void Update()
        {

        }

        [ExposeProperty]
        public bool Edible
        {
            get
            {
                return _edible;
            }
            set
            {
                _edible = value;
            }
        }

       [ExposeProperty]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}

