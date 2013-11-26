using Assets.Scripts.EntityPositionCalculator;
using Assets.Scripts.EntityPositionCalculator.Generators;
using Assets.Scripts.Score;
using FruitKiller;
using Game.Common;
using UnityEngine;
using UnityDI;
namespace Assets.Scripts
{
    public class GameStarter:MonoBehaviour
    {
		private Container _container;

		public GameObject Plane;
        public Vector3 EntityDistance;
        public IScorePrinter _scorePrinter;
        public GUIText ScorePlace;
        public Vector3 EntityScale;
        private Vector3 _boundaryCenterCoordinate;
        private Vector3 _boundaryScale;

        private IEntityPlacer _entityPlacer;


		
		public void Start()
		{
			SetupContainer();
			_boundaryCenterCoordinate = Plane.transform.position;
			_boundaryScale = Plane.transform.localScale;
		    _entityPlacer = _container.Resolve<IEntityPlacer>();
            _entityPlacer.PlaceEntity(_boundaryCenterCoordinate, _boundaryScale, EntityDistance, EntityScale);

		    _scorePrinter=_container.Resolve<IScorePrinter>();
            _scorePrinter.SetPlaceForPrint(ScorePlace);
		}
		
		public void Update()
		{
            _entityPlacer.CreateEntities();
			_scorePrinter.Print();
		}
		
		private void SetupContainer()
		{
			_container = new Container();
            _container.RegisterType<Entity>();
            _container.RegisterType<IEntityPositionPlacer, RectanglePositionPlacer>();
            _container.RegisterType<IEntityPlacer, EntityPlacer>();
            _container.RegisterType<ITouchConroller, MouseClickConroller>();
            _container.RegisterType<IScorePrinter, ScorePrinter>();
		    _container.RegisterInstance<IDIContainer>(_container);
		    var entityFactory = new EntityFactory("Prefabs/Entities");
            _container.BuildUp(entityFactory);
            _container.RegisterInstance<IEntityFactory>(entityFactory);
		    var scoreManager = new ScoreManager();
		    _container.RegisterInstance<IScoreManager>(scoreManager);
		}
    }
}
