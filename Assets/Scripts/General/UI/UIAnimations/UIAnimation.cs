using UnityEngine;
using System;

namespace Hexaplex.UI
{
    public abstract class UIAnimation
    {
        public abstract void Play(GameObject target, Action callback = null);
    }

    public abstract class UIAnimation<T> : UIAnimation where T : MonoBehaviour
    {
        public override void Play(GameObject target, Action callback = null)
        {
            T component = target.GetComponent<T>();
            if (!component)
            {
                throw new Exception(
                    string.Format(
                        "{0} doesn't have any {1} component attached to it, the {2} animation can't be played",
                        target.name,
                        typeof(T).Name,
                        GetType().Name
                    )
                );
            }

            Play(target.GetComponent<T>(), callback);
        }

        public abstract void Play(T target, Action callback = null);
    }
}