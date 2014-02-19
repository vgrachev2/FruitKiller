using Assets.Scripts.Entity;
using Assets.Scripts.EventHandlers.Entities;
using Assets.Scripts.Events;
using Assets.Scripts.Grid;
using Assets.Scripts.Grid.EntityPositionCalculator;
using Assets.Scripts.Grid.EntityPositionCalculator.Generators;
using Assets.Scripts.LevelControllers;
using Assets.Scripts.MenuButtons;
using Assets.Scripts.Score;
using FruitKiller;
using Game.Common;
using UnityDI;
using Assets.Scripts.Score.ScorePlane;
using Assets.Plugins.Game.Common;

namespace Assets.Scripts {
	public class ContainerInstaller {
		public Container Install()
		{
			var container = new Container();
			container.RegisterType<MainMenuController>();
            container.RegisterType<GameController>();
            container.RegisterType<EventManager>();
		   
            container.RegisterType<CharacterSelectController>();
			container.RegisterType<Entity.Entity>();
            container.RegisterType<IEntityGridCreator, RectangleGridCreator>();
			container.RegisterType<IEntityGridManager, EntityGridManager>();
			container.RegisterType<ITouchConroller, MouseClickConroller>();
			container.RegisterType<IMenuButtonFactory, MenuButtonFactory>();
		    container.RegisterType<IAudioClipLoader, AudioClipLoader>();
			container.RegisterType<IAudioPlayer,AudioPlayer> ();
		    container.RegisterType<IProgressBar, ProgressBar>();
          
			container.RegisterInstance<IDIContainer>(container);
			var entityFactory = new EntityFactory("Prefabs/Entities");
			container.BuildUp(entityFactory);
			container.RegisterInstance<IEntityFactory>(entityFactory);

		
			container.RegisterType<IScorePrinter,ScorePrinter>();
			container.RegisterSingleton<IScoreManager,ScoreManager> ();
            container.RegisterSingleton<ICountdownTimer, CountdownTimer>();
		
		
			return container;
		}
	}
}
