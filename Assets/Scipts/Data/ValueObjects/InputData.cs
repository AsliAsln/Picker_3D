using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObjects
{
    [Serializable]
    public struct InputData
    {
        public float HorizontalInputSpeed;
        public Vector2 ClampValues;
        public float clampSpeed;

    }
}
