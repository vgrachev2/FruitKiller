using UnityEngine;

namespace Game.Common
{
    public class MultiTouchConroller : ITouchConroller
    {
        public bool Touched(GameObject gameObject)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    var cursorRay = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (gameObject.collider.Raycast(cursorRay, out hit, 1000.0f))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}