using Ships.Weapons;
using System;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public partial class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;

        
        [SerializeField] private Vector2 _horizontalBound;
        [SerializeField] private Vector2 _verticalBound;
        
        private Input _input;

        public void Configure(Input input, ICheckLimits checkLimits)
        {
            _input = input;
            _movementController.Configure(this, checkLimits);
            _weaponController.Configure(this);
        }

        private void Update()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            } 
        }
    }
}
