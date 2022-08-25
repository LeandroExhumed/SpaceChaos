using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorController : IController
    {
        private readonly IOffscreenMovementModel offscreenMovement;
        private readonly IDamageableModel health;
        private readonly MeteorView view;
        private readonly OffscreenDetector offscreenDetector;

        private readonly AudioProvider audioProvider;

        public MeteorController (
            IOffscreenMovementModel offscreenMovement,
            IDamageableModel health,
            MeteorView view,
            OffscreenDetector offscreenDetector,
            AudioProvider audioProvider)
        {
            this.offscreenMovement = offscreenMovement;
            this.health = health;
            this.view = view;
            this.offscreenDetector = offscreenDetector;
            this.audioProvider = audioProvider;
        }

        public void Setup ()
        {
            health.OnDeath += HandleDeath;
            view.OnCollision += HandleCollision;
            offscreenDetector.OnOffscreen += HandleOffscreen;
        }

        private void HandleDeath (IDamageableModel _)
        {
            view.Destroy();
            audioProvider.PlayOneShot(SoundType.Explosion);
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
            offscreenMovement.Overflow();
        }

        public void Dispose ()
        {
            health.OnDeath -= HandleDeath;
            view.OnCollision -= HandleCollision;
            offscreenDetector.OnOffscreen -= HandleOffscreen;
        }
    }
}