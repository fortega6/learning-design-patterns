﻿using UnityEngine;

namespace Patterns.Behaviour.Mediator
{
    public class Autopilot : MonoBehaviour
    {
        private Vehicle _vehicle;
        public void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
        private void OnTriggerEnter(Collider other)
        {
            _vehicle.ObstacleDetected();
        }
    }
}