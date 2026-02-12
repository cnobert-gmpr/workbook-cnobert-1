using System;
using UnityEngine;

namespace GMPR2512
{
    public class ShowGizmo : MonoBehaviour
    {
        [SerializeField] private Color _gizmoColor = Color.red;
        [SerializeField] private float _radius = 0.5f;
        void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColor;
            //"transform" represents the transform of the game object to which this script is attached
            //we could have used GetComponent<Transform>().position
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}