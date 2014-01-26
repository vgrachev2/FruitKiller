using Assets.Scripts.Entity;
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
            container.RegisterType<CharacterSelectController>();
			container.RegisterType<Entity.Entity>();
            container.RegisterType<IEntityGridCreator, RectangleGridCreator>();
			container.RegisterType<IEntityGridManager, EntityGridManager>();
			container.RegisterType<ITouchConroller, MouseClickConroller>();
			container.RegisterType<IMenuButtonFactory, MenuButtonFactory>();
			container.RegisterType<IScorePrinter, ScorePrinter>();
			container.RegisterType<IAudioClipLoader,AudioClipLoader> ();
			container.RegisterType<IAudioPlayer,AudioPlayer> ();
		    container.RegisterType<IProgressBar, ProgressBar>();
			container.RegisterInstance<IDIContainer>(container);
			var entityFactory = new EntityFactory("Prefabs/Entities");
			container.BuildUp(entityFactory);
			container.RegisterInstance<IEntityFactory>(entityFactory);
			var scoreManager = new ScoreManager();
			container.RegisterInstance<IScoreManager>(scoreManager);
			var scorePlaneCreator = new ScorePlaneManipulator(10);
            container.RegisterType<ICountdownTimer, CountdownTimer>();
		
			container.RegisterInstance<IScorePlaneManipulator> (scorePlaneCreator);
			return container;
		}
	}
}
