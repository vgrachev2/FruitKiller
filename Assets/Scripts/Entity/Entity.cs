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
		public Color ColorExplosive;

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
                    
                    Delete();
                }
            }
        }

        private void CreateNewEntityInColumn()
        {
            EntitySpawner.Spawn();
        }

        private void EmulateExplosion(){
			var prefab = Resources.Load ("Prefabs/Additions/DestroyExplosion");
            
			var position = this.gameObject.transform.position;
			var component = Instantiate (prefab, new Vector3 (position.x, position.y, -10), Quaternion.identity) as GameObject;
			ParticleSystemColorSet(component.particleSystem);
		}

        private void ParticleSystemColorSet(ParticleSystem m_currentParticleEffect)
        {

            //var psColor = Color.Lerp(ColorExplosive, Color.white,1f);
			var color = Color.black;
			m_currentParticleEffect.startColor = ColorExplosive;
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

        void Delete(){
			this.gameObject.renderer.sortingOrder = 0;
            EmulateExplosion();
          //  StartAnimation();
            Destroy(this.gameObject);
        }

        private void StartAnimation(){
            var component = this.GetComponent<Animator>();
            component.SetTrigger("Destroy");
        }
    }
}

