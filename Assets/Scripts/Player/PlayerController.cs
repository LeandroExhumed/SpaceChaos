using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using SpaceChaos.AudioSystem;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class PlayerController : IController
    {
        private readonly MovementModel movement;
        private readonly ShooterModel shooter;
        private readonly IDamageableModel health;
        private readonly PlayerView view;

        private readonly AudioManager audioManager;

        public void Setup ()
        {
            movement.OnThrusterNeedChanged += HandleThrusterNeedChanged;
            shooter.OnShot += HandleShot;
            health.OnDeath += HandleDeath;
            health.OnResurrection += HandleResurrection;
            view.OnInvencibleBlinkinhEffectOver += HandleInvencibleBlinkinhEffectOver;
        }

        private void HandleThrusterNeedChanged (bool needed)
        {
            view.SetThrusterActive(needed);
        }

        private void HandleShot ()
        {
            audioManager.playSound(AudioManager.SoundType.LaserShot);
        }

        private void HandleDeath (IDamageableModel _)
        {
            view.SetColliderActive(false);
            view.DisableMeshes();
            view.PlayExplosionVFX();
            audioManager.playSound(AudioManager.SoundType.Explosion);
        }

        private void HandleResurrection ()
        {
            movement.Reset();
            view.StartRespawnBlinking();
        }

        private void HandleInvencibleBlinkinhEffectOver ()
        {
            view.SetColliderActive(true);
        }

        public void Dispose ()
        {
            movement.OnThrusterNeedChanged -= HandleThrusterNeedChanged;
            shooter.OnShot -= HandleShot;
            health.OnDeath -= HandleDeath;
            health.OnResurrection -= HandleResurrection;
            view.OnInvencibleBlinkinhEffectOver -= HandleInvencibleBlinkinhEffectOver;
        }
    }
}