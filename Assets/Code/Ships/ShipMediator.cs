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

        [SerializeField] private ShipId _shipId;
        
        [SerializeField] private Vector2 _horizontalBound;
        [SerializeField] private Vector2 _verticalBound;
        public string Id => _shipId.Value;
        
        private Input.Input _input;


        public void Configure(Input.Input input, CheckLimits.ICheckLimits checkLimits,
                             Vector2 speed, float fireRate, ProjectileId defaultProjectileId)
        {
            _input = input;
            _movementController.Configure(this, checkLimits, speed);
            _weaponController.Configure(this, fireRate, defaultProjectileId);
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
