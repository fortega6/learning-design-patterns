using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _brakeLights;

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Break"))
            {
                Pressed();
            }
            else if (UnityEngine.Input.GetButtonUp("Break"))
            {
                Release();
            }
        }

        private void Pressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.AddFriction();
            }

            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.TurnOn();
            }
        }

        private void Release()
        {
            foreach (var wheel in _wheels)
            {
                wheel.RemoveFriction();
            }

            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.TurnOff();
            }
        }
    }
}
