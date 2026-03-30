using System.Collections;
using UnityEngine;

public sealed class FreezeZone : MonoBehaviour
{
    [SerializeField] private float _freezeSeconds = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;

        if (rb == null)
        {
            return;
        }

        StartCoroutine(FreezeRoutine(rb));
    }

    private IEnumerator FreezeRoutine(Rigidbody2D rb)
    {
        Vector2 savedVelocity = rb.linearVelocity;
        float savedGravity = rb.gravityScale;

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;

        yield return new WaitForSeconds(_freezeSeconds);

        rb.gravityScale = savedGravity;
        rb.linearVelocity = savedVelocity;
    }
}