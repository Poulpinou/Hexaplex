using UnityEngine;
using System;

namespace Hexaplex.UI.Animations
{
    [Serializable]
    public class Translate : UIAnimation<UIComponent>, IReversableAnimation<UIComponent>
    {
        [SerializeField]
        private float duration = .5f;

        [SerializeField]
        private Vector2 startPosition;

        [SerializeField]
        private Vector2 endPosition;


        public override void Play(UIComponent target, Action callback = null)
        {
            target.RectTransform.anchoredPosition = startPosition;

            LeanTween.move(target.RectTransform, endPosition, duration)
                .setOnComplete(callback);
        }

        public void PlayReversed(GameObject target, Action callback = null) => PlayReversed(target.GetComponent<UIComponent>(), callback);

        public void PlayReversed(UIComponent target, Action callback = null)
        {
            target.RectTransform.anchoredPosition = endPosition;

            LeanTween.move(target.RectTransform, startPosition, duration)
                .setOnComplete(callback);
        }
    }
}