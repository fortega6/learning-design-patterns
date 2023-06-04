using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleLight : MonoBehaviour
    {
        [SerializeField] private Light _light;
        public void TurnOn()
        {
            _light.enabled = true;
        }

        public void TurnOff()
        {
            _light.enabled = false;
        }
    }
}
