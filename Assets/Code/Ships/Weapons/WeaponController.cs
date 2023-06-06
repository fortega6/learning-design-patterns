using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile[] _projectilePrefabs;
        [SerializeField] private Transform _projectileSpawnPosition;

        private Ship _ship;
        private float _remainingSecondsToBeAbleToShoot;

        private string _activeProjectileId;

        public void Configure(Ship ship)
        {
            _ship = ship;
            _activeProjectileId = "Projectile2";
        }

        public void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }
            Shoot();
        }

        private void Shoot()
        {
            var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(_activeProjectileId));
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}