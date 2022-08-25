using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using System.Linq;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    class ProjectileController : IController
    {
        private readonly int[] targetLayers;

        private readonly IProjectileModel model;
        private readonly ProjectileView view;
        private readonly OffscreenDetector offscreenDetector;

        public ProjectileController (
            IProjectileModel model,
            ProjectileView view,
            OffscreenDetector offscreenDetector,
            int[] targetLayers)
        {
            this.model = model;
            this.view = view;
            this.offscreenDetector = offscreenDetector;
            this.targetLayers = targetLayers;
        }

        public void Setup ()
        {
            model.OnDestroyed += HandleDestroyed;
            view.OnTriggerEntered += HandleTriggerEntered;
            offscreenDetector.OnOffscreen += HandleOffscreen;
        }

        private void HandleTriggerEntered (Collider collider)
        {
            if (targetLayers.Contains(collider.gameObject.layer))
            {
                model.Destroy();
                IDamageableModel damageable = collider.GetComponentInParent<IDamageableModel>();
                if (damageable != null)
                {
                    damageable.TakeDamage();
                }
            }
        }

        private void HandleDestroyed ()
        {
            view.Destroy();
        }

        private void HandleOffscreen ()
        {
            model.Destroy();
        }

        public void Dispose ()
        {
            model.OnDestroyed -= HandleDestroyed;
            view.OnTriggerEntered -= HandleTriggerEntered;
            offscreenDetector.OnOffscreen -= HandleOffscreen;
        }
    }
}