using UnityEngine;
using UnityEngine.InputSystem;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5, _rotationSpeed = 200, _scaleSpeed = 1;
        
        [SerializeField] private float _minRotation = 25, _maxRotation = -25;

        private InputAction _moveAction, _rotationAction, _scaleAction;

        void Awake()
        {
            // this creates and input method that is decoupled from the input device
            _moveAction = InputSystem.actions.FindAction("Player/Move");
            _rotationAction = InputSystem.actions.FindAction("Player/Move");
            _scaleAction = InputSystem.actions.FindAction("Player/Scale");
        }

        void Update()
        {
            #region movement
            Vector2 moveDirection = new Vector2(_moveAction.ReadValue<Vector2>().x, 0);
            Vector2 translation = moveDirection.normalized * _movementSpeed * Time.deltaTime;
            transform.Translate(translation, Space.Self);
            #endregion

            #region rotation
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
            #endregion
        
            #region scaling
            float scaleValue = _scaleAction.ReadValue<float>() * _scaleSpeed * Time.deltaTime;
            Vector3 scaleChange = new Vector3(scaleValue, scaleValue, scaleValue);
            transform.localScale += scaleChange;

            Vector3 scale = transform.localScale;
            if(scale.x < 0)
                scale.x = 0;
            if(scale.y < 0)
                scale.y = 0;
            if(scale.z < 0)
                scale.z = 0;
            transform.localScale = scale;

            #endregion
        }
    }
}
