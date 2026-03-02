using UnityEngine;
using UnityEngine.InputSystem;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5;

        private InputAction _moveAction;

        void Awake()
        {
            // this creates and input method that is decoupled from the input device
            _moveAction = InputSystem.actions.FindAction("Player/Move");
        }

        void Update()
        {
            Vector2 moveDirection = _moveAction.ReadValue<Vector2>();
            
            transform.Translate(new Vector3(-Time.deltaTime, Time.deltaTime, 0));
        }
    }
}
