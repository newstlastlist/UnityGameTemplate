using UnityEngine;

namespace Helpers.Visualization
{
    public class GizmoHelper
    {
        public static void DrawSphere(Vector3 position, float radius, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(position, radius);
        }

        public static void DrawLine(Vector3 from, Vector3 to, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(from, to);
        }

        public static void DrawCube(Transform transform, BoxCollider collider, Color color)
        {
            Gizmos.color = color;
            Vector3 size = new Vector3(
                transform.localScale.x * collider.size.x, 
                transform.localScale.y * collider.size.y,
                transform.localScale.z * collider.size.z);
            
            Gizmos.DrawCube(transform.position + collider.center, size);
        }

        public static void DrawCube(Vector3 position, Vector3 size, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawCube(position, size);
        }

        public static void DrawWireCube(Transform transform, BoxCollider collider, Color color)
        {
            Gizmos.color = color;
            Vector3 size = new Vector3(
                transform.localScale.x * collider.size.x, 
                transform.localScale.y * collider.size.y,
                transform.localScale.z * collider.size.z);
            
            Gizmos.DrawWireCube(transform.position + collider.center, size);
        }
        public static void DrawWireCube(Vector3 position, Vector3 size, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawWireCube(position, size);
        }


        public enum GizmoType
        {
            Sphere,
            Line,
            CubeFromBoxCollider,
            CubeFromGivenSize
        }
    }
}