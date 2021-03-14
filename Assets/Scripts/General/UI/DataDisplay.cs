using UnityEngine;

namespace Hexaplex.UI {
	public abstract class DataDisplay<TData> : MonoBehaviour where TData : IListenableData
    {
        protected TData data;

        public virtual TData Data
        {
            get => data;
            set
            {
                ClearDisplay();

                data = value;

                if(data != null)
                {
                    data.OnDataChanged.AddListener(RefreshDisplay);
                    InitDisplay();
                }
            }
        }


        protected virtual void InitDisplay()
        {
            if(data != null)
            {
                OnInitDisplay();
                RefreshDisplay();
            }
        }

        public virtual void RefreshDisplay()
        {
            if (data != null)
            {
                OnRefreshDisplay();
            }
        }

        public virtual void ClearDisplay() => OnClearDisplay();

        protected abstract void OnInitDisplay();

        protected abstract void OnRefreshDisplay();

        protected abstract void OnClearDisplay();
    }
}