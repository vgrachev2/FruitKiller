 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
 using Object = UnityEngine.Object;

namespace Assets.Scripts.Score.ScorePlane
{
    public class ScorePlaneManipulator: MonoBehaviour, IScorePlaneManipulator
    {
		private GameObject _workPlane;
      
        private int _numberOfItem;
		private int count=0;
        private Object _prefab;
        private float _planePartWidth;
        private float _startx;

        public ScorePlaneManipulator(int numberOfItem)
		{
			_numberOfItem = numberOfItem;
            _prefab = Resources.Load("Prefabs/ScorePlaneItem/scorePlaneItem");
		}

        public GameObject WorkPlane
        {
            get { return _workPlane; }
            set { _workPlane = value; }
        }

        public void Create()
        {
			_planePartWidth = 1/(float)_numberOfItem;
		    _startx =(float)(-((float)1/2 - (float)(_planePartWidth/2)));
            for (int indexInPlane = 0; indexInPlane < _numberOfItem; indexInPlane++)
            {
                CreatePlaneItemAndPositionalIt(indexInPlane);
            }
        }

        private void CreatePlaneItemAndPositionalIt(int indexInPlane)
        {
            var newCube = CreatePlaneItem(_prefab, indexInPlane);
            PositionalItemInPlane(newCube, _planePartWidth, _startx, indexInPlane);
        }

        private static void PositionalItemInPlane(GameObject newCube, float planePartWidth, float startx, int indexInPlane)
        {
            newCube.transform.localScale = new Vector3(planePartWidth, 1);
            newCube.transform.localPosition = new Vector3(startx + indexInPlane*planePartWidth, 0);
        }

        private GameObject CreatePlaneItem(Object prefab,int indexInPlane)
        {
            var newCube = (GameObject) Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            newCube.tag = "progressBarItem";
            newCube.transform.parent = WorkPlane.transform;
            var script = newCube.GetComponent<ScorePlaneItem>();
            script.Index = indexInPlane;
            return newCube;
        }


        public void DeleteFirstPlaneItem()
        {
			try{
				if(count>100){
					count=0;
					var items=GameObject.FindGameObjectsWithTag("progressBarItem");
                    var scorePlaneItemScripts = GetScriptsFromGameObjectsList<ScorePlaneItem>(items);
				    var min=scorePlaneItemScripts.Min(x => x.Index);
				    var deletedPlaneItem = scorePlaneItemScripts.FirstOrDefault(x => x.Index == min);
					if(deletedPlaneItem !=null){
						deletedPlaneItem.Destroy();
					}
				}

				count++;

			}
			catch(Exception e){
				Debug.Log(e.InnerException);
			}
            
        }

        private IEnumerable<T> GetScriptsFromGameObjectsList<T>(IEnumerable<GameObject> items) where T:MonoBehaviour
        {
            List<T> scorePlaneItemScripts=new List<T>();
            foreach (var component in items)
            {
                var scorePlaneItem = component.GetComponent<T>();
                scorePlaneItemScripts.Add(scorePlaneItem);
            }
            return scorePlaneItemScripts;
        }


        public void AddNewPlaneItem()
        {
            var items = GameObject.FindGameObjectsWithTag("progressBarItem");
            var deletedItemsCount = _numberOfItem-items.Count();
            if (deletedItemsCount != 0)
            {
                CreatePlaneItemAndPositionalIt(deletedItemsCount-1);
            }
        }
    }
}
