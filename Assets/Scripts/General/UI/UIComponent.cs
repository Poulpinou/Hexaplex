using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.UI {
    [RequireComponent(typeof(RectTransform))]
	public abstract class UIComponent : MonoBehaviour
    {
        private bool isDisplayed;


        public RectTransform RectTransform { get; private set; }

        public bool IsDisplayed
        {
            get => isDisplayed;
            set
            {
                isDisplayed = value;
                if (isDisplayed)
                {
                    OnShow();
                }
                else
                {
                    OnHide();
                }
            }
        }


        public void SwitchDisplay() => IsDisplayed = !IsDisplayed;

        protected abstract void OnShow();

        protected abstract void OnHide();

        protected virtual void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }
}