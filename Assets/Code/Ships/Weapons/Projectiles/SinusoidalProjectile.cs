using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _amplitude;
        [SerializeField] private int _frequency;
        
        private float _currentTime;
        private Vector3 _currentPosition;

        protected override void DoStart()
        {
            _currentTime = 0;
            _currentPosition = transform.position;
        }

        protected override void DoMove()
        {
            _currentPosition += MyTransform.up * (_speed * Time.deltaTime);
            var horizontalPosition = MyTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
            Debug.Log(_currentPosition);
            _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);
            _currentTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {
        }
    }
}
