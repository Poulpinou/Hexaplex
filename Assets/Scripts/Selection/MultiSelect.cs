using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Selection {
    public struct MultiSelect : ISelectable
    {
        #region Fields
        private List<ISelectable> selections;

        private bool selected;
        #endregion

        #region Properties
        public ISelectable[] Selections => selections.ToArray();

        public bool Selected
        {
            get => selected;
            private set
            {
                selected = value;
                UpdateStates();
            }
        }
        #endregion

        #region Constructors
        public MultiSelect(ISelectable[] selectables, bool selected = false)
        {
            selections = new List<ISelectable>(selectables);
            this.selected = selected;
        }
        #endregion

        #region Static Methods
        public static MultiSelect Of(params ISelectable[] selectables) => new MultiSelect(selectables);
        #endregion

        #region Methods
        public void Select()
        {
            Selected = true;
        }

        public void Deselect()
        {
            Selected = false;
        }

        public bool IsSelected() => Selected;

        public void UpdateStates()
        {
            foreach (ISelectable selectable in selections)
            {
                if (selected && !selectable.IsSelected())
                {
                    selectable.Select();
                }
                else if (!selected && selectable.IsSelected())
                {
                    selectable.Deselect();
                }
            }
        }

        public override string ToString()
        {
            return string.Format("MultiSelect({0}, {1} elements)", selected ? "Selected" : "Deselected", selections.Count);
        }
        #endregion

        #region Operators
        public static MultiSelect operator +(MultiSelect multi, ISelectable selectable)
        {
            multi.selections.Add(selectable);
            multi.UpdateStates();

            return multi;
        }

        public static MultiSelect operator -(MultiSelect multi, ISelectable selectable)
        {
            if (multi.selections.Contains(selectable))
            {
                multi.selections.Remove(selectable);
                multi.UpdateStates();
            }

            return multi;
        }
        #endregion
    }
}