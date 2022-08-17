using SpaceChaos.Constants;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class DriftModel
    {
        private float speed = 50f;
        private const float EDGE_OFFSET = 0.5F;

        private readonly Transform transform;
        private readonly Rigidbody rigidbody;

        public void Move ()
        {
            rigidbody.AddForce(transform.up * speed);
        }

        public void HandleCollision (Collider other)
        {
            if (other.CompareTag(Tags.SPACE_WIDTH_LIMIT))
            {
                TeleportOnHorizontal();
            }

            if (other.CompareTag(Tags.SPACE_HEIGHT_LIMIT))
            {
                TeleportOnVertical();
            }
        }

        private void TeleportOnHorizontal ()
        {
            Vector3 newPosition = transform.position;
            float forward = rigidbody.velocity.normalized.x * EDGE_OFFSET;
            newPosition.x = -newPosition.x + forward;

            transform.position = newPosition;
        }

        private void TeleportOnVertical ()
        {
            Vector3 newPosition = transform.position;
            float forward = rigidbody.velocity.normalized.y * EDGE_OFFSET;
            newPosition.y = -newPosition.y + forward;

            transform.position = newPosition;
        }

        public void IncreaseSpeed ()
        {
            speed *= 1.5f;
        }
    }
}