using UnityEngine;

namespace GMPR2512.Lesson05DeathzoneAndRespawn
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Portal _pairedPortal;
        [SerializeField] private Transform _exitPoint;
        [SerializeField] private float _reentryLockSeconds = 0.2f;

        private float _lockedUntil;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            // rigidbody of the ball
            Rigidbody2D rb = collider.attachedRigidbody;
            if(rb == null || Time.time < _lockedUntil)
            {
                return;
            }
            _lockedUntil = Time.time + _reentryLockSeconds;
            _pairedPortal._lockedUntil = Time.time + _reentryLockSeconds;

            rb.linearVelocity = Vector3.zero;
            rb.position = _exitPoint.position;
        }
    }
}
