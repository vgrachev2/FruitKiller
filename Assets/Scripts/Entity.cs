using Assets.Scripts.Score;
using FruitKiller.Base;
using Game.Common;
using UnityDI;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace FruitKiller
{
    public class Entity : MonoBehaviour
    {
        private const int _entityScore=10;
        
        public bool Edible;
        public string Name;

        [UnityDI.Dependency]
        public ITouchConroller Conroller  { private get; set; }

        [UnityDI.Dependency]
        public IScoreManager ScoreManager { private get; set; }

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
                    if (Edible)
                    {
                        ScoreManager.PlusValueToScore(_entityScore);
                    }
                    else
                    {
                        ScoreManager.MinusValueToScore(_entityScore);
                    }
                }
            }
        }

        void Delete()
        {
            Destroy(this);
        }
    }
}

