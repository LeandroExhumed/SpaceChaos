using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Services.Audio;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOController : IController
    {
        private readonly IRouteMovement routeMovement;
        private readonly IOffscreenDetectorModel offscreenDetector;
        private readonly IAutoShotingModel autoShoting;
        private readonly IDamageableModel health;
        private readonly UFOView view;

        private readonly AudioProvider audioProvider;

        public UFOController (
            IRouteMovement routeMovement,
            IOffscreenDetectorModel offscreenDetector,
            IAutoShotingModel autoShoting,
            IDamageableModel health,
            UFOView view,
            AudioProvider audioProvider)
        {
            this.routeMovement = routeMovement;
            this.offscreenDetector = offscreenDetector;
            this.autoShoting = autoShoting;
            this.health = health;
            this.view = view;
            this.audioProvider = audioProvider;
        }

        public void Setup ()
        {
            routeMovement.OnLeaving += HandleLeaving;
            health.OnDeath += HandleDeath;
            view.OnUpdate += HandleUpdate;
            view.OnCollision += HandleCollision;
        }

        private void HandleLeaving (string _)
        {
            view.Destroy();
        }

        private void HandleDeath (DeathInfo _)
        {
            view.PlayExplosionVFX();
            view.Destroy();
            audioProvider.PlayOneShot(SoundType.Explosion);
        }

        private void HandleUpdate ()
        {
            routeMovement.Tick();
            offscreenDetector.Tick();
            autoShoting.Tick();
        }

        private void HandleCollision (Collider collider)
        {
            if (collider.TryGetComponent(out IDamageableModel damageable))
            {
                damageable.TakeDamage();
            }

            health.TakeDamage();
        }

        public void Dispose ()
        {
            routeMovement.OnLeaving -= HandleLeaving;
            health.OnDeath -= HandleDeath;
            view.OnUpdate -= HandleUpdate;
            view.OnCollision -= HandleCollision;
        }
    }
}