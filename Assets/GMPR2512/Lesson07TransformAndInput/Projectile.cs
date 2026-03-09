using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Projectile : MonoBehaviour
    {
        private float _speed = 10, _spinVelocity = 0;
        private Vector2 _direction = Vector2.up;

        internal Vector2 Direction { set => _direction = value; }
        internal float Speed { set => _speed = value; }
        internal float SpinVelocity { set => _spinVelocity = value; }
        
        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);
            transform.Rotate(new Vector3(0, 0, _spinVelocity * Time.deltaTime), Space.World);
        }
    }
}
