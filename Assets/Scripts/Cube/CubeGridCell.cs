using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

namespace Hexaplex.Cube {
    /// <summary>
    /// This is a UI cell linked to a <see cref="CubeTile"/> that allows interactions with
    /// it and display some of its states
    /// </summary>
	public class CubeGridCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Header("Relations")]
        [SerializeField]
        private Image image;


        [Header("Cell sprites")]
        [SerializeField]
        private Sprite normal;

        [SerializeField]
        private Sprite hover;


        public Cubxel Cubxel { get; private set; }

        public bool Built { get; private set; }


        public CubeGridCell Build(Cubxel cubxel)
        {
            if (Built)
            {
                throw new Exception("The cell has been built already");
            }

            Cubxel = cubxel;

            Built = true;

            return this;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CubeEvents.OnCellClick.Invoke(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.sprite = hover;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.sprite = normal;
        }
    }
}