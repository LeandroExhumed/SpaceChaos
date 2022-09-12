using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class LaunchableModel : ILaunchableModel
    {
        private readonly float speed;

        protected readonly Transform transform;
        protected readonly Rigidbody rigidbody;
        protected Collider collider;

        public LaunchableModel (float speed, Transform transform, Rigidbody rigidbody, Collider collider)
        {
            this.speed = speed;
            this.transform = transform;
            this.rigidbody = rigidbody;
            this.collider = collider;
        }

        public virtual void Initialize (Vector3 position, Quaternion rotation, Collider owner = null)
        {
            transform.position = position;
            transform.rotation = rotation;

            if (owner != null)
            {
                IgnoreCollisionWIthOwner(owner); 
            }
        }

        public void GetLaunched ()
        {
            rigidbody.AddForce(transform.forward * speed);
        }

        private void IgnoreCollisionWIthOwner (Collider ownerCollider)
        {
            Physics.IgnoreCollision(ownerCollider, collider);
        }
    }
}