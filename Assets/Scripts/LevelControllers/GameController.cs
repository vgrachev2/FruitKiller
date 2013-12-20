using System.Collections;
using Assets.Scripts.Grid;
using Assets.Scripts.Score;
using Assets.Scripts.Score.ScorePlane;
using UnityEngine;
using Assets.Plugins.Game.Common;

namespace Assets.Scripts.LevelControllers
{
    public class GameController:MonoBehaviour
    {
		public GameObject Plane;
        public GameObject ProgressPlane;
        public Vector3 EntityDistance;
        public Vector3 EntityScale;
        public GUIText ScorePlace;
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
            _scorePrinter.SetPlaceForPrint(ScorePlace);
		    _scorePlaneManuManipulator = container.Resolve<IScorePlaneManipulator>();
			_scorePlaneManuManipulator.WorkPlane = ProgressPlane;
            _scorePlaneManuManipulator.Create();
			var audioPlayer = container.Resolve<IAudioPlayer> ();
			audioPlayer.Play ("victory");
		    scoreManager.ScoreManipulator = _scorePlaneManuManipulator;
		    _countdownTimer = container.Resolve<ICountdownTimer>();
            _countdownTimer.StartCountdown(30f, () => Application.LoadLevel("MainMenu"));
            StartCoroutine(Coroutine());
		}
		
		public void Update()
		{
		    _entityGridManager.InitializationEntitiesInGrid();
			_scorePrinter.Print();
            _countdownTimer.Update();
            _scorePlaneManuManipulator.DeleteFirstPlaneItem();
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
        }
		
    }
}
