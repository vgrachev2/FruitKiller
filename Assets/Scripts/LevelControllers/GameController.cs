using System.Collections;
using Assets.Scripts.Events;
using Assets.Scripts.Grid;
using Assets.Scripts.Score;
using Assets.Scripts.Score.ScorePlane;
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
        public IScorePrinter _scorePrinter;
        private IEntityGridManager _entityGridManager;
        private IScorePlaneManipulator _scorePlaneManuManipulator;
        private ICountdownTimer _countdownTimer;

		public void Start()
		{
		    var container = new ContainerInstaller().Install();
		    var boundaryCenterCoordinate = Plane.transform.position;
			var boundaryScale = Plane.transform.localScale;
		    _entityGridManager = container.Resolve<IEntityGridManager>();
            _scorePrinter = container.Resolve<IScorePrinter>();
		    var scoreManager = container.Resolve<IScoreManager>();
            _entityGridManager.InitializationGrid(boundaryCenterCoordinate, boundaryScale, EntityDistance, EntityScale);
			var audioPlayer = container.Resolve<IAudioPlayer> ();
            audioPlayer.PlayLoop("MainTheme");
		    scoreManager.ScoreManipulator = _scorePlaneManuManipulator;
		    _countdownTimer = container.Resolve<ICountdownTimer>();
            _countdownTimer.StartCountdown(30f, ShowMenu);
            StartCoroutine(Coroutine());
			BuildSelectedCharacter ();
		}

        public void ShowMenu()
        {
            EventManager.instance.TriggerEvent(new GameFinished());
        }
		
		public void Update()
		{
		    _entityGridManager.InitializationEntitiesInGrid();
            _countdownTimer.Update();
           
		}

        public IEnumerator Coroutine()
        {
            while (true)
            {
                float time = Time.realtimeSinceStartup;
                _entityGridManager.RecreateDestroyedEntity();

                yield return new WaitForSeconds(2.00f);
            }
        }

        void OnGUI()
        {
            _countdownTimer.OnGUI();
            _scorePrinter.Print(CorrectScorePlace.transform.position, IncorrectScorePlace.transform.position);
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
