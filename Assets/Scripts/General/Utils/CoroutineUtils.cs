using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hexaplex {
    public static class CoroutineUtils
    {
        public delegate void FailureCallback(Exception e);

        public static IEnumerator<T> Try<T>(IEnumerator<T> enumerator, FailureCallback callback)
        {
            while (true)
            {
                T current;
                try
                {
                    if (enumerator.MoveNext() == false)
                    {
                        break;
                    }
                    current = enumerator.Current;
                }
                catch (Exception e)
                {
                    callback(e);
                    yield break;
                }
                yield return current;
            }
        }

        public static IEnumerator Try(IEnumerator enumerator, FailureCallback callback)
        {
            while (true)
            {
                object current;
                try
                {
                    if (enumerator.MoveNext() == false)
                    {
                        break;
                    }
                    current = enumerator.Current;
                }
                catch (Exception e)
                {
                    callback(e);
                    yield break;
                }
                yield return current;
            }
        }
    }
}