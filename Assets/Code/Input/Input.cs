using System.Collections;
using UnityEngine;

namespace Ships
{
    public interface Input
    {
        Vector2 GetDirection();
        bool IsFireActionPressed();
    }
}