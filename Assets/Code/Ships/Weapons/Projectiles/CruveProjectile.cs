using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CruveProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _horizontalPosition;

        private float _currentTime;
        private Vector3 _currentPosition;
        private Transform _myTransform;

        private void Start()
        {
            _currentTime = 0;
            _myTransform = transform;
            _currentPosition = transform.position;
            StartCoroutine(DestroyIn(4));
        }

        private void FixedUpdate()
        {
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);
            var horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);
            Debug.Log(_currentPosition);
            _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);
            _currentTime += Time.deltaTime;
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
