using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Hexaplex.Battles.UI {
	public class BattleBanner : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        [SerializeField]
        private Image background;


        public void DrawText(string text, Action callback = null) {
            Init();

            LTSeq sequence = LeanTween.sequence();
            sequence.append(() => this.text.text = text);
            sequence.append(() => LeanTween.size(background.rectTransform, new Vector2(background.rectTransform.sizeDelta.x, 100), 0.5f));
            sequence.append(0.3f);
            sequence.append(() => LeanTween.moveX(this.text.gameObject, Screen.width / 2, 0.3f).setEaseOutElastic());
            sequence.append(2f);
            sequence.append(() => LeanTween.moveX(this.text.gameObject, Screen.width * 2, 0.3f).setEaseInElastic());
            sequence.append(() => LeanTween.size(background.rectTransform, new Vector2(background.rectTransform.sizeDelta.x, 0), 0.3f).setOnComplete(callback));

            Init();
        }

        private void Init()
        {
            background.rectTransform.sizeDelta *= new Vector2(1, 0);
            text.rectTransform.anchoredPosition = new Vector2(-Screen.width, 0);
        }

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                DrawText("This is a test!", () => Debug.Log("Done"));
            }
        }
    }
}