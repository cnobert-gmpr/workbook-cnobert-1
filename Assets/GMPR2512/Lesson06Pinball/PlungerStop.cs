using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class PlungerStop : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            // normally we would just check the tag
            if(collision.gameObject.name == "Plunger")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
}
