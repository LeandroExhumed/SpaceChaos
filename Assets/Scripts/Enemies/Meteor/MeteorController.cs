using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorController : IController
    {
        private readonly IOffscreenDetectorModel offscreenDetector;
        private readonly ISplittableModel splitting;
        private readonly IDamageableModel health;
        private readonly MeteorView view;

        private readonly AudioProvider audioProvider;

        public MeteorController (
            IOffscreenDetectorModel offscreenDetector,
            ISplittableModel splitting,
            IDamageableModel health,
            MeteorView view,
            AudioProvider audioProvider)
        {
            this.offscreenDetector = offscreenDetector;
            this.splitting = splitting;
            this.health = health;
            this.view = view;
            this.audioProvider = audioProvider;
        }

        public void Setup ()
        {
            health.OnDeath += HandleDeath;
            view.OnUpdate += HandleUpdate;
            view.OnCollision += HandleCollision;
        }

        private void HandleDeath (DeathInfo _)
        {
            splitting.Split();
            view.Destroy();
            audioProvider.PlayOneShot(SoundType.Explosion);
        }

        private void HandleUpdate ()
        {
            offscreenDetector.Tick();
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
            health.OnDeath -= HandleDeath;
            view.OnUpdate -= HandleUpdate;
            view.OnCollision -= HandleCollision;
        }
    }
}