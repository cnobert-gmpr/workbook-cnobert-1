using UnityEngine;
using UnityEngine.InputSystem;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5, _rotationSpeed = 200, _scaleSpeed = 1;
        [SerializeField] private float _minRotation = 25, _maxRotation = -25;

        [SerializeField] private float _projectileSpeed = 5, _projectileSpinVelocity = -2000;

        [SerializeField] private GameObject _projectilePrefab;

        private InputAction _moveAction, _rotationAction, _scaleAction, _fireAction;

        void Awake()
        {
            // this creates and input method that is decoupled from the input device
            _moveAction = InputSystem.actions.FindAction("Player/Move");
            _rotationAction = InputSystem.actions.FindAction("Player/Move");
            _scaleAction = InputSystem.actions.FindAction("Player/Scale");
            _fireAction = InputSystem.actions.FindAction("Player/Jump");
        }

        //Unity will keep the input actions disabled by default
        //for efficiency reasons. So, we need to enable/disable them.
        //It's best practice to include the methods below.
        void OnEnable()
        {
            _moveAction?.Enable();
            _rotationAction?.Enable();
            _scaleAction?.Enable();
            
            if(_fireAction != null)
            {
                _fireAction.Enable();
                //register methods with the fire action
                _fireAction.performed += FireButtonPressed;
                _fireAction.canceled += FireButtonReleased;
            }
        }

        void OnDisable()
        {
            _moveAction?.Disable();
            _rotationAction?.Disable();
            _scaleAction?.Disable();
            _fireAction?.Disable();
        }

        void Update()
        {
            #region movement
            Vector2 moveDirection = new Vector2(_moveAction.ReadValue<Vector2>().x, 0);
            Vector2 translation = moveDirection.normalized * _movementSpeed * Time.deltaTime;
            transform.Translate(translation, Space.World);
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
    
        private void FireButtonPressed(InputAction.CallbackContext context)
        {
            Vector3 projectileStartPosition = transform.GetChild(0).position;
            GameObject theProjectile = 
                Instantiate(_projectilePrefab, projectileStartPosition, transform.rotation);
            // declare a "Projectile" variable and make it refer to the script that 
            // is a component of the projectile that we just instantiated
            Projectile projectileScript = theProjectile.GetComponent<Projectile>();
            projectileScript.Speed = _projectileSpeed;
            projectileScript.Direction = transform.up;
            projectileScript.SpinVelocity = _projectileSpinVelocity;;
        }
        private void FireButtonReleased(InputAction.CallbackContext context)
        {
           
        }

    }
}
