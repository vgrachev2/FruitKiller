using Assets.Scripts.Events;
using Assets.Scripts.Events.Entities;
using Assets.Scripts.Score;
using Game.Common;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class Entity : MonoBehaviour
    {
        private const int _entityScore=10;
        
        public bool Edible;
        public string Name;

        [Dependency]
        public ITouchConroller Conroller  { private get; set; }

        [Dependency]
        public IScoreManager ScoreManager { private get; set; }


        public IEntitySpawner EntitySpawner { get; set; }

        // Use this for initialization
        void Start()
        {

        }

        
        // Update is called once per frame
        void Update()
        {
            if (Conroller != null)
            {
                if (Conroller.BeginTouched(this.gameObject))
                {
                    ChangeScore();
                    CreateNewEntityInColumn();
                    if (Edible)
                    {
                        EventManager.instance.TriggerEvent(new EntityEatableSelected());
                    }
                    else
                    {
                        EventManager.instance.TriggerEvent(new EntityNotEatableSelected());
                    }
                    
                    Destroy(this.gameObject);
                }
            }
        }

        private void CreateNewEntityInColumn()
        {
            EntitySpawner.Spawn();
        }

        private void ChangeScore()
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

        void Delete()
        {
            Destroy(this);
        }
    }
}

