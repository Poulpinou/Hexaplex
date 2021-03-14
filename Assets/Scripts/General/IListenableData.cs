using UnityEngine.Events;

namespace Hexaplex {

    public class DataChangedEvent : UnityEvent { }

    public class DataChangedEvent<T> : UnityEvent<T> { }


    public interface IListenableData
    { 
        DataChangedEvent OnDataChanged { get; }
    }

    public interface IListenableData<T>
    {
        DataChangedEvent<T> OnDataChanged { get; }
    }
}