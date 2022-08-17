using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using SpaceChaos.AudioSystem;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorController : IController
    {
        private readonly DriftModel drift;
        private readonly IDamageableModel health;
        private readonly MeteorView view;

        private readonly AudioManager audioManager;

        public void Setup ()
        {
            health.OnDeath += HandleDeath;
            view.OnCollision += HandleCollision;
        }

        private void HandleDeath (IDamageableModel _)
        {
            view.DisableCollider();
            view.DisableMesh();
            view.CreateDestructionVFX();
            audioManager.playSound(AudioManager.SoundType.Explosion);
        }

        private void HandleCollision (Collider other)
        {
            drift.HandleCollision(other);
        }

        public void Dispose ()
        {
            health.OnDeath -= HandleDeath;
            view.OnCollision -= HandleCollision;
        }
    }
}