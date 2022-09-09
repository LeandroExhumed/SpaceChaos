using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOController : IController
    {
        private readonly IRouteMovement routeMovement;
        private readonly IDamageableModel health;
        private readonly UFOView view;
        private readonly OffscreenDetector offscreenDetector;

        private readonly AudioProvider audioProvider;

        public UFOController (
            IRouteMovement routeMovement,
            IDamageableModel health,
            UFOView view,
            OffscreenDetector offscreenDetector,
            AudioProvider audioProvider)
        {
            this.routeMovement = routeMovement;
            this.health = health;
            this.view = view;
            this.offscreenDetector = offscreenDetector;
            this.audioProvider = audioProvider;
        }

        public void Setup ()
        {
            health.OnDeath += HandleDeath;
            view.OnUpdate += HandleViewUpdate;
            view.OnCollision += HandleCollision;
            offscreenDetector.OnOffscreen += HandleOffscreen;
        }

        private void HandleDeath (DeathInfo _)
        {
            view.PlayExplosionVFX();
            view.Destroy();
            audioProvider.PlayOneShot(SoundType.Explosion);
        }

        private void HandleViewUpdate ()
        {
            routeMovement.Tick();
        }

        private void HandleCollision (Collider collider)
        {
            if (collider.TryGetComponent(out IDamageableModel damageable))
            {
                damageable.TakeDamage();
            }

            health.TakeDamage();
        }

        private void HandleOffscreen ()
        {
            view.Destroy();
        }

        public void Dispose ()
        {
            health.OnDeath -= HandleDeath;
            view.OnUpdate -= HandleViewUpdate;
            view.OnCollision -= HandleCollision;
            offscreenDetector.OnOffscreen -= HandleOffscreen;
        }
    }
}