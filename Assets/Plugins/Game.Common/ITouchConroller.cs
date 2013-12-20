using UnityEngine;

namespace Game.Common
{
    public interface ITouchConroller
    {
        bool BeginTouched(GameObject gameObject);

        bool CompleteTouched(GameObject gameObject);
    }
}
