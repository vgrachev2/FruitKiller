using System.Collections;
using Assets.Scripts.Grid;
using Assets.Scripts.Score;
using UnityEngine;

namespace Assets.Scripts.LevelControllers
{
    public class GameController:MonoBehaviour
    {
		public GameObject Plane;
        public Vector3 EntityDistance;
        public Vector3 EntityScale;
        public GUIText ScorePlace;
        
        public IScorePrinter _scorePrinter;
        private IEntityGridManager _entityGridManager;

		
		public void Start()
		{
		    var container = new ContainerInstaller().Install();
		    var boundaryCenterCoordinate = Plane.transform.position;
			var boundaryScale = Plane.transform.localScale;
		    _entityGridManager = container.Resolve<IEntityGridManager>();
			Debug.Log("dadwa");
            _scorePrinter = container.Resolve<IScorePrinter>();
            _entityGridManager.InitializationGrid(boundaryCenterCoordinate, boundaryScale, EntityDistance, EntityScale);
            _scorePrinter.SetPlaceForPrint(ScorePlace);
            StartCoroutine(Coroutine());
		}
		
		public void Update()
		{
		    _entityGridManager.InitializationEntitiesInGrid();
			_scorePrinter.Print();
		}

        public IEnumerator Coroutine()
        {
            while (true)
            {
                float time = Time.realtimeSinceStartup;
                _entityGridManager.RecreateDestroyedEntity();
				Debug.Log("Корутина вызвалась");
                yield return new WaitForSeconds(2.00f);
            }
        }
		
    }
}
