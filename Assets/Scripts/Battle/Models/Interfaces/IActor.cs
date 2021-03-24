using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
	public interface IActor
    {
        string Name { get; }

        Sprite Picture { get; }

        float Speed { get; }
    }
}