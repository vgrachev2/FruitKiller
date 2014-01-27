using UnityEngine;

namespace Game.Common
{
    public class MouseClickConroller : ITouchConroller
    {
        public bool BeginTouched(GameObject gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				if(hit.collider!=null){
				if(hit.collider.transform.gameObject == gameObject)
				{
				    return true;
				}
				}
            }

            return false;
        }

        public bool CompleteTouched(GameObject gameObject)
        {
            return false;
        }
    }
}