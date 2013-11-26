using System.Runtime.InteropServices;
using Assets.Scripts.EntityPositionCalculator;
using Assets.Scripts.EntityPositionCalculator.Generators;
using Assets.Scripts.LevelControllers;
using Assets.Scripts.MenuButtons;
using Assets.Scripts.Score;
using FruitKiller;
using Game.Common;
using UnityDI;

namespace Assets.Scripts {
	public class ContainerInstaller {
		public Container Install()
		{
			var container = new Container();
			container.RegisterType<MainMenuController>();
			container.RegisterType<Entity>();
			container.RegisterType<IEntityPositionPlacer, RectanglePositionPlacer>();
			container.RegisterType<IEntityPlacer, EntityPlacer>();
			container.RegisterType<ITouchConroller, MouseClickConroller>();
			container.RegisterType<IMenuButtonFactory, MenuButtonFactory>();
			container.RegisterType<IScorePrinter, ScorePrinter>();
			container.RegisterInstance<IDIContainer>(container);
			var entityFactory = new EntityFactory("Prefabs/Entities");
			container.BuildUp(entityFactory);
			container.RegisterInstance<IEntityFactory>(entityFactory);
			var scoreManager = new ScoreManager();
			container.RegisterInstance<IScoreManager>(scoreManager);
			return container;
		}
	}
}
