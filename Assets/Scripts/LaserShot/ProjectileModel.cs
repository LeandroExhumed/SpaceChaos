using LeandroExhumed.SpaceChaos.Common;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public class ProjectileModel : LaunchableModel, IProjectileModel
    {
        public event Action OnReused;
        public event Action OnDestroyed;

        private readonly IOffscreenDetectorModel offscreenDetector;

        public ProjectileModel (
            IOffscreenDetectorModel offscreenDetector,
            float speed,
            Transform transform,
            Rigidbody rigidbody,
            Collider collider) : base (speed, transform, rigidbody, collider)
        {
            this.offscreenDetector = offscreenDetector;
        }

        public override void Initialize (Vector3 position, Quaternion rotation, Collider owner = null)
        {
            base.Initialize(position, rotation, owner);
            offscreenDetector.OnOffscreen += OnOffscreen;
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

        private void OnOffscreen (Edge edge)
        {
            Destroy();
        }
    }
}