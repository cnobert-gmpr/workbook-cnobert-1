using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05DeathzoneAndRespawn
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if(collider2D.gameObject.CompareTag("Ball"))
            {
                //wait two seconds, respawn the ball at a pre-determined spawnpoint
                StartCoroutine(RespawnBall(collider2D.gameObject));
            }
        }
        private IEnumerator RespawnBall(GameObject ball)
        {
            yield return new WaitForSeconds(2);
            
            Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
            ballRB.linearVelocity = Vector2.zero;
            ballRB.angularVelocity = 0;
            // whatever we want to happen in 2 seconds goes here
            ball.transform.position = _spawnPoint.position;
        }
    }
}
