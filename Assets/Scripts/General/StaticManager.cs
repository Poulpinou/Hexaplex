using UnityEngine;
using System;

namespace Hexaplex {
    [DefaultExecutionOrder(-100)]
    public abstract class StaticManager<T> : MonoBehaviour where T: StaticManager<T>
    {
        [SerializeField]
        protected bool dontDestroyOnLoad;


        private static T instance;


        public static T Instance { 
            get
            {
                if(instance == null)
                {
                    throw new Exception(string.Format("No instance of {0} in the scene", typeof(T).Name));
                }
                return instance;
            }
            private set
            {
                instance = value;   
            } 
        }

        protected virtual void Awake()
        {
            T previous = FindObjectOfType<T>();
            if (previous != this)
            {
                Debug.LogError(string.Format("Another {0}, exist in the scene, this is not allowed (see {1}). This instance will be deleted.", typeof(T).Name, previous.name));
                Destroy(this);
            }
            else
            {
                Instance = GetComponent<T>();
                if (dontDestroyOnLoad)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
        }
    }
}