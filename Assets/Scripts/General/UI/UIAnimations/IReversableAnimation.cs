using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hexaplex.UI.Animations {
	public interface IReversableAnimation
    {
        void PlayReversed(GameObject target, Action callback = null);
    }

    public interface IReversableAnimation<T> : IReversableAnimation
    {
        void PlayReversed(T target, Action callback = null);
    }
}