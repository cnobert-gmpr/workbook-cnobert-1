using UnityEngine;
using UnityEngine.InputSystem;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5, _rotationSpeed = 200;
        
        [SerializeField] private float _minRotation = 25, _maxRotation = -25;

        private InputAction _moveAction, _rotationAction;

        void Awake()
        {
            // this creates and input method that is decoupled from the input device
            _moveAction = InputSystem.actions.FindAction("Player/Move");
            _rotationAction = InputSystem.actions.FindAction("Player/Move");
        }

        void Update()
        {
            Vector2 moveDirection = new Vector2(_moveAction.ReadValue<Vector2>().x, 0);
            Vector2 translation = moveDirection.normalized * _movementSpeed * Time.deltaTime;
            transform.Translate(translation, Space.Self);

            float rotationValue = _rotationAction.ReadValue<Vector2>().normalized.y * _rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationValue);

            // Clamp rotation
            Vector3 euler = transform.eulerAngles;
            // Convert to signed range (-180 to 180)
            if (euler.z > 180f)
            {
                euler.z -= 360f;
            }
            // Clamp, then assign back
            euler.z = Mathf.Clamp(euler.z, _maxRotation, _minRotation);
            transform.eulerAngles = euler;

        }
    }
}
