using Ships.Common;
using Ships.Weapons.Projectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;
        [SerializeField] private Transform _projectileSpawnPosition;

        private float _fireRateInSeconds;
        private Teams _team;
        private Ship _ship;
        private float _remainingSecondsToBeAbleToShoot;
        private ProjectileFactory _projectileFactory;

        private string _activeProjectileId;

        private List<Projectile> _aliveProjectiles;

        private void Awake()
        {
            var instance = Instantiate(_projectilesConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
            _aliveProjectiles = new List<Projectile>();
        }

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId, Teams team)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;
            _team = team;
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
            var projectile = _projectileFactory
                .Create(_activeProjectileId, 
                        _projectileSpawnPosition.position, 
                        _projectileSpawnPosition.rotation,
                        _team);
            _aliveProjectiles.Add(projectile);
            projectile.OnDestroy += OnProjectileDestroy;
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
        }

        private void OnProjectileDestroy(Projectile projectile)
        {
            _aliveProjectiles.Remove(projectile);
            projectile.OnDestroy -= OnProjectileDestroy;
        }

        public void Restart()
        {
            foreach (var aliveProjectile in _aliveProjectiles)
            {
                Destroy(aliveProjectile.gameObject);
            }

            _aliveProjectiles.Clear();
        }
    }
}