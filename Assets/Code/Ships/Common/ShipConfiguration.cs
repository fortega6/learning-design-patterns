using Ships.CheckLimits;
using Ships.Weapons;
using UnityEngine;

namespace Ships.Common
{
    public class ShipConfiguration
    {
        public readonly Input.Input Input;
        public readonly CheckLimits.ICheckLimits CheckLimits;
        public readonly Vector2 Speed;
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectileId;

        public ShipConfiguration(Input.Input input, ICheckLimits checkLimits, Vector2 speed, float fireRate, ProjectileId defaultProjectileId)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
        }
    }
}
