using UnityEditor;
using UnityEngine;

namespace Patterns.Behaviour.Mediator
{
    public interface Vehicle
    {
        void BrakePressed();
        void BrakeRelease();
        void LeftPressed();
        void RightPressed();
        void ObstacleDetected();
    }
}