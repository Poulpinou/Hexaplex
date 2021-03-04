using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Hexaplex.Selection {
	public class SelectionManager : StaticManager<SelectionManager>
    {
        [Serializable]
        public class SelectionEvent : UnityEvent<ISelectable> { }

        [Header("Events")]
        [SerializeField]
        private SelectionEvent onSelectionChanged = new SelectionEvent();


        private ISelectable selected;


        public static SelectionEvent OnSelectionChanged => Instance.onSelectionChanged;

        public static ISelectable Selected
        {
            get => Instance.selected;
            set
            {
                Instance.selected?.Deselect();

                Instance.selected = value;

                Instance.selected?.Select();

                Instance.onSelectionChanged.Invoke(Instance.selected);
            }
        }

        public static bool IsMultiSelect
        {
            get => Selected is MultiSelect;
            set {
                if (value && !IsMultiSelect)
                {
                    Instance.selected = MultiSelect.Of(Selected);
                }
                else if (!value && IsMultiSelect)
                {
                    MultiSelect selection = (MultiSelect)Selected;

                    if (selection.Selections.Length > 1)
                    {
                        throw new Exception("There is more than one element in the selection, impossible to enable single select");
                    }

                    if (selection.Selections.Length == 1)
                    {
                        Instance.selected = selection.Selections[0];
                    }
                    else
                    {
                        Instance.selected = null;
                    }
                }
            }
        }

        public static void AddToSelection(ISelectable selectable)
        {
            if (!IsMultiSelect)
            {
                IsMultiSelect = true;
            }

            Selected = (MultiSelect) Selected + selectable;
        }
    }
}