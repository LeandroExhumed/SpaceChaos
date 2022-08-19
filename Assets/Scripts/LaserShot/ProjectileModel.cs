using LeandroExhumed.SpaceChaos.Common.Damage;
using SpaceChaos.Constants;
using System;
using System.Linq;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public class ProjectileModel : IProjectileModel
    {
        public event Action OnReused;
        public event Action OnDestroyed;
        
        private readonly float speed;
        private readonly int[] targetLayers;

        private readonly Transform transform;
        private readonly Rigidbody rigidbody;

        public ProjectileModel (float speed, int[] targetLayers, Transform transform, Rigidbody rigidbody)
        {
            this.speed = speed;
            this.targetLayers = targetLayers;
            this.transform = transform;
            this.rigidbody = rigidbody;
        }

        public void Initialize (Vector3 position, Vector3 rotation)
        {
            rigidbody.position = position;
            transform.forward = rotation;
        }

        public void GetLaunched ()
        {
            rigidbody.AddForce(transform.forward * speed);
        }

        public void HandleCollision (Collider colider)
        {
            if (colider.TryGetComponent(out IDamageableModel damageable))
            {
                damageable.TakeDamage();
            }

            if (targetLayers.Contains(colider.gameObject.layer))
            {
                Destroy();
            }

            if (colider.CompareTag(Tags.SPACE_WIDTH_LIMIT) || colider.CompareTag(Tags.SPACE_HEIGHT_LIMIT))
            {
                Destroy();
            }
        }

        public void Reuse ()
        {
            rigidbody.velocity = Vector3.zero;
            OnReused?.Invoke();
        }

        public void Destroy ()
        {
            OnDestroyed?.Invoke();
        }
    }
}