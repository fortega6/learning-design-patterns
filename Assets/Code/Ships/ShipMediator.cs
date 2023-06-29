using Ships.Common;
using Ships.Weapons;
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


        public void Configure(ShipConfiguration configuration)
        {
            _input = configuration.Input;
            _movementController.Configure(this, configuration.CheckLimits, configuration.Speed);
            _weaponController.Configure(this, configuration.FireRate, configuration.DefaultProjectileId);
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Ship collided: " + other.name);
        }
    }
}
