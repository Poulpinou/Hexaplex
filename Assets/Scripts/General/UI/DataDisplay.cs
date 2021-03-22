using UnityEngine;

namespace Hexaplex.UI {
    public abstract class DataDisplay : UIComponent {
        protected virtual bool HideOnNullData => true;

        public abstract void RefreshDisplay();

        public virtual void ClearDisplay() => OnClearDisplay();

        protected virtual void OnInitDisplay() => OnRefreshDisplay();

        protected abstract void OnRefreshDisplay();

        protected abstract void OnClearDisplay();
    }

	public abstract class DataDisplay<TData> : DataDisplay
    {
        protected TData data;

        public TData Data
        {
            get => data;
            set
            {
                if (data is IListenableData) {
                    ((IListenableData) data)?.OnDataChanged.RemoveListener(RefreshDisplay);
                }
                

                ClearDisplay();

                data = value;

                if(data != null)
                {
                    if (data is IListenableData)
                    {
                        ((IListenableData)data)?.OnDataChanged.AddListener(RefreshDisplay);
                    }

                    InitDisplay();
                    IsDisplayed = true;
                }
                else if(HideOnNullData)
                {
                    IsDisplayed = false;
                }
            }
        }

        protected void InitDisplay()
        {
            if (data != null)
            {
                OnInitDisplay();
            }
        }

        public override sealed void RefreshDisplay()
        {
            if (data != null)
            {
                OnRefreshDisplay();
            }
        }
    }
}