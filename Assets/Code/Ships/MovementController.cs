using System.Collections;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Ship _ship;
        private Transform _myTransform;
        private ICheckLimits _checkLimits;


        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(Ship ship, ICheckLimits checkLimits)
        {
            _ship = ship;
            _checkLimits = checkLimits;
        }

        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }
    }
}