using Assets.Scripts.EntityPositionCalculator;
using Assets.Scripts.EntityPositionCalculator.Generators;
using FruitKiller;
using Game.Common;
using UnityEngine;
using UnityDI;
namespace Assets.Scripts
{
    public class GameStarter:MonoBehaviour
    {
		private Container _container;
	//	private GameMain _gameMain;
		
		public void Start()
		{
			SetupContainer();
			
			_container.Resolve<IEntityPlacer>().PlaceEntity();
		}
		
		public void Update()
		{
			//_gameMain.Update(Time.deltaTime);
		}
		
		private void SetupContainer()
		{
			_container = new Container();
            _container.RegisterType<Entity>();
		//	_container.RegisterType<TimeSlicer>();
		//	_container.RegisterType<IInput3D, Input3D>();
            _container.RegisterType<IEntityPositionGenerator, RectanglePositionGenerator>();
            _container.RegisterType<IEntityPlacer, EntityPlacer>();
            _container.RegisterType<ITouchConroller, MouseClickConroller>();
		    _container.RegisterInstance<IDIContainer>(_container);
		    var entityFactory = new EntityFactory("Prefabs/Entities");
            _container.BuildUp(entityFactory);
            _container.RegisterInstance<IEntityFactory>(entityFactory);
		    //	_container.RegisterType<IAsteroidField, AsteroidField>();
		    //	_container.RegisterSingleton<IFlight, Flight>();
		    ///	_container.RegisterSceneObject<IAsteroidFactory>("AsteroidRespawn");
		    ///	_container.RegisterSceneObject<ISpaceShip>("Ship");
		    //	_container.RegisterSceneObject<IFxPlayer>("Effects");
		    //	_container.RegisterSceneObject<IMainMenu>("Interface");
		    //	_container.RegisterSceneObject<IHud>("Interface");
		}
    }
}
