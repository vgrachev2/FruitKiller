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
            _scorePrinter = container.Resolve<IScorePrinter>();
            _entityGridManager.InitializationGrid(boundaryCenterCoordinate, boundaryScale, EntityDistance, EntityScale);
            _scorePrinter.SetPlaceForPrint(ScorePlace);
		}
		
		public void Update()
		{
            _entityGridManager.InitializationEntitiesInGrid();
			_scorePrinter.Print();
		}
		
    }
}
