using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LinealProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
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
