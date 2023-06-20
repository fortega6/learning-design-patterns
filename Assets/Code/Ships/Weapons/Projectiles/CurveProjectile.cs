using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _horizontalPosition;

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
            var horizontalPosition = MyTransform.right * _horizontalPosition.Evaluate(_currentTime);
            Debug.Log(_currentPosition);
            _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);
            _currentTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {
        }
    }
}
