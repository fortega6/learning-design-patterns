using Ships.Weapons;
using System;
using UnityEngine;

namespace Ships
{
    public partial class Ship : MonoBehaviour
    {

        [SerializeField] private float _speed;
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnPosition;
        [SerializeField] private Vector2 _horizontalBound;
        [SerializeField] private Vector2 _verticalBound;
        
        private Input _input;
        private Transform _myTransform;
        private ICheckLimits _checkLimits;
        private float _remainingSecondsToBeAbleToShoot;
        

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(Input input, ICheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }

            if (_input.IsFireActionPressed())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(_projectilePrefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}
