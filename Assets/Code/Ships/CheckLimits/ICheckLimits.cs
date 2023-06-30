﻿
using UnityEngine;

namespace Ships.CheckLimits
{
    public interface ICheckLimits
    {
        Vector2 ClampFinalPosition(Vector2 currentPosition);
    }
}
