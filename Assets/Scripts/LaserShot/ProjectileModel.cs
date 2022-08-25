using LeandroExhumed.SpaceChaos.Common;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public class ProjectileModel : LaunchableModel, IProjectileModel
    {
        public event Action OnReused;
        public event Action OnDestroyed;

        public ProjectileModel (
            float speed,
            Transform transform,
            Rigidbody rigidbody,
            Collider collider) : base (speed, transform, rigidbody, collider)
        {
        }

        public void HandleCollision (Collider colider)
        {
            
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