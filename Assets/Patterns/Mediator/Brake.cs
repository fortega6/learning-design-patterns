using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _brakeLights;
        private Vehicle _vehicle;

        public void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Break"))
            {
                _vehicle.BrakePressed();
            }
            else if (UnityEngine.Input.GetButtonUp("Break"))
            {
                _vehicle.BrakeRelease();
            }
        }
    }
}
