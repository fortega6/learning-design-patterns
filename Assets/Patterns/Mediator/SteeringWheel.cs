using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class SteeringWheel : MonoBehaviour
    {
        [SerializeField] private Wheel[] _wheels;

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Left"))
            {
                TurnLeft();
            }
            else if (UnityEngine.Input.GetButtonDown("Right"))
            {
                TurnRight();
            }
        }

        private void TurnLeft()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnLeft();
            }
        }

        private void TurnRight()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnRight();
            }
        }
    }
}
