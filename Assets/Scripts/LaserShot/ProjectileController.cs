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
        private readonly IOffscreenDetectorModel offscreenDetector;

        public ProjectileController (
            IProjectileModel model,
            ProjectileView view,
            IOffscreenDetectorModel offscreenDetector,
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
            view.OnUpdate += HandleUpdate;
            view.OnTriggerEntered += HandleTriggerEntered;
            offscreenDetector.OnOffscreen += HandleOffscreen;
        }

        private void HandleUpdate ()
        {
            offscreenDetector.Tick();
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

        private void HandleOffscreen (Edge edge)
        {
            model.Destroy();
        }

        public void Dispose ()
        {
            model.OnDestroyed -= HandleDestroyed;
            view.OnUpdate -= HandleUpdate;
            view.OnTriggerEntered -= HandleTriggerEntered;
            offscreenDetector.OnOffscreen -= HandleOffscreen;
        }
    }
}