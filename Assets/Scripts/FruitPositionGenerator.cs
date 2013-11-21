using FruitKiller;
using UnityEngine;

namespace Assets.Scripts
{
    public class FruitPositionGenerator:MonoBehaviour
    {
        void Start()
        {
			var fruits = GameObject.FindGameObjectsWithTag("Fruit");
            foreach (GameObject fruit in fruits)
            {
                fruit.transform.position=new Vector3(0,0,0);
            }
        }

        

        void Update()
        {
            
        }
    }
}
