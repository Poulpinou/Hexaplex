using UnityEngine;
using System;

namespace Hexaplex {
    [AttributeUsage(AttributeTargets.Field)]
    public class ReadonlyAttribute : PropertyAttribute
    {
        
    }
}