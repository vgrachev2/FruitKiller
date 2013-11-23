using UnityEngine;

namespace Game.Common
{
    public class MouseClickConroller : ITouchConroller
    {
        public bool Touched(GameObject gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(cursorRay, out hit))
                {
                    return hit.collider == gameObject.collider;
                }
            }

            return false;
        }
    }
}