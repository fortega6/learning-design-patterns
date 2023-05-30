using UnityEngine;

namespace Ships
{
    public partial class Ship : MonoBehaviour
    {

        [SerializeField] private float _speed;
        private Input _input;
        [SerializeField] private Vector2 _horizontalBound;
        [SerializeField] private Vector2 _verticalBound;
        private Transform _myTransform;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _myTransform = transform;
        }

        public void Configure(Input input)
        {
            _input = input;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            ClampFinalPosition();
        }

        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, _horizontalBound.x, _horizontalBound.y);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, _verticalBound.x, _verticalBound.y);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}
