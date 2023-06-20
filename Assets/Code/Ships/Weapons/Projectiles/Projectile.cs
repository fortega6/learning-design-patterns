﻿using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _rigidbody2D;
        [SerializeField] private ProjectileId _id;

        protected Transform MyTransform;

        public string Id => _id.Value;

        private void Start()
        {
            MyTransform = transform;
            DoStart();
            StartCoroutine(DestroyIn(5));
        }

        protected abstract void DoStart();

        private void FixedUpdate()
        {
            DoMove();
        }

        protected abstract void DoMove();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DestroyProjectile();
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        
        private void DestroyProjectile()
        {
            DoDestroy();
            Destroy(gameObject);
        }
        protected abstract void DoDestroy();
    }
}
