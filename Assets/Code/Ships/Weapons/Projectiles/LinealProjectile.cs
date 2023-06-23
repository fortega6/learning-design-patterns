using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class LinealProjectile : Projectile
    {
        [SerializeField] private float _speed;

        protected override void DoStart()
        {
            _rigidbody2D.velocity = transform.up * _speed;
        }

        protected override void DoDestroy()
        {
        }

        protected override void DoMove()
        {
        }

    }
}
