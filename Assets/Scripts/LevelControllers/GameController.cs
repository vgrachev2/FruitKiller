using System.Collections;
using Assets.Scripts.Events;
using Assets.Scripts.Grid;
using Assets.Scripts.Score;
using Assets.Scripts.Score.ScorePlane;
using UnityDI;
using UnityEngine;
using Assets.Plugins.Game.Common;
using Assets.Scripts.MenuButtons;

namespace Assets.Scripts.LevelControllers
{
    public class GameController:MonoBehaviour
    {
		public GameObject Plane;
      
        public Vector3 EntityDistance;
        public Vector3 EntityScale;
        public GUIText ScorePlace;
        public GameObject IncorrectScorePlace; 
        public GameObject CorrectScorePlace;
        public int fontSize;

		public GameObject SpawnerPlace1;
		public GameObject SpawnerPlace2;
		public GameObject SpawnerPlace3;

        [Dependency]
        public IMenuButtonFactory _menuButtonFactory { get; set; }

        [Dependency]
        public IDIContainer DIContainer { private get; set; }
       
        private IScorePlaneManipulator _scorePlaneManuManipulator;
        private ICountdownTimer _countdownTimer;
        private EntitySpawner _spawner;
		private IScorePrinter _scorePrinter;

		public void Start()
		{
		    var container = ContainerSingletone.Container;
		    var boundaryCenterCoordinate = Plane.transform.position;
			var boundaryScale = Plane.transform.localScale;
		    var spawner1=new EntitySpawner();

			container.BuildUp(spawner1);
            spawner1.Start(SpawnerPlace1.transform.position);

            var spawner2 = new EntitySpawner();
			container.BuildUp(spawner2);
			spawner2.Start(SpawnerPlace2.transform.position);
			
			var spawner3 = new EntitySpawner();
			container.BuildUp(spawner3);
			spawner3.Start(SpawnerPlace3.transform.position);
			
			
			var scoreManager = container.Resolve<IScoreManager>();

			var audioPlayer = container.Resolve<IAudioPlayer> ();
           audioPlayer.PlayLoop("MainTheme");
		    scoreManager.ScoreManipulator = _scorePlaneManuManipulator;
		    _countdownTimer = container.Resolve<ICountdownTimer>();
            _countdownTimer.StartCountdown(5f, ShowMenu);
			_scorePrinter = container.Resolve<IScorePrinter> ();
		    _scorePrinter.CorrectScorePlace = CorrectScorePlace;
		    _scorePrinter.IncorrectScorePlace = IncorrectScorePlace;
		    _scorePrinter.FontSize = fontSize;
		    _menuButtonFactory = container.Resolve<IMenuButtonFactory>();
			BuildSelectedCharacter ();
		    BuildSettingsButton();

		}

        private void BuildSettingsButton()
        {
            _menuButtonFactory.BuildButton(() => EventManager.instance.TriggerEvent(new PauseButtonClicked()), "Prefabs/Buttons/SettingsButton", new Vector3(1.156599f, -0.611589f, 0), this.gameObject);
        }


        public void ShowMenu()
        {
            EventManager.instance.TriggerEvent(new GameFinished());
        }
		
		public void Update()
		{
		  
			if(_countdownTimer!=null)
            _countdownTimer.Update();
           
		}

      

        void OnGUI()
        {
			_scorePrinter.Print ();
            _countdownTimer.OnGUI();
          
            
        }

		public void BuildSelectedCharacter(){
			var selectedCharacter = PlayerPrefs.GetString ("ChoisedCharacter");
            var prefab = Resources.Load("Prefabs/characters/GameSceneCharactersPrefabs/" + selectedCharacter);
			var component = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			//component.transform.parent = Plane.transform;
            component.transform.localPosition = new Vector3(3.103868f, 0.6147761f, 0);
		}
    }
}
