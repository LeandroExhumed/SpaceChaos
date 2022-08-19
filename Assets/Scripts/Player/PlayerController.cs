using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Input;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class PlayerController : IController
    {
        private readonly IMovementModel movement;
        private readonly IShooterModel shooter;
        private readonly IDamageableModel health;
        private readonly PlayerView view;
        
        private readonly IInput input;
        private readonly AudioProvider audioProvider;

        public PlayerController (
            IMovementModel movement,
            IShooterModel shooter,
            IDamageableModel health,
            PlayerView view,
            IInput input,
            AudioProvider audioProvider)
        {
            this.movement = movement;
            this.shooter = shooter;
            this.health = health;
            this.view = view;
            this.input = input;
            this.audioProvider = audioProvider;
        }

        public void Setup ()
        {
            movement.OnThrusterNeedChanged += HandleThrusterNeedChanged;
            shooter.OnShot += HandleShot;
            health.OnDeath += HandleDeath;
            health.OnResurrection += HandleResurrection;
            view.OnInvencibleBlinkinhEffectOver += HandleInvencibleBlinkinhEffectOver;
            view.OnUpdate += HandleUpdate;
            input.OnShotPerformed += HandleShotPerformed;
        }

        private void HandleThrusterNeedChanged (bool needed)
        {
            view.SetThrusterActive(needed);
        }

        private void HandleShot ()
        {
            audioProvider.PlayOneShot(SoundType.LaserShot);
        }

        private void HandleDeath (IDamageableModel _)
        {
            view.SetColliderActive(false);
            view.DisableMeshes();
            view.PlayExplosionVFX();
            input.SetActive(false);
            audioProvider.PlayOneShot(SoundType.Explosion);
        }

        private void HandleResurrection ()
        {
            movement.Reset();
            view.StartRespawnBlinking();
            input.SetActive(true);
        }

        private void HandleInvencibleBlinkinhEffectOver ()
        {
            view.SetColliderActive(true);
        }

        private void HandleUpdate ()
        {
            movement.Steer(input.Steer);
            movement.Thrust(input.Thrust);
        }

        private void HandleShotPerformed ()
        {
            shooter.Shot();
        }

        public void Dispose ()
        {
            movement.OnThrusterNeedChanged -= HandleThrusterNeedChanged;
            shooter.OnShot -= HandleShot;
            health.OnDeath -= HandleDeath;
            health.OnResurrection -= HandleResurrection;
            view.OnInvencibleBlinkinhEffectOver -= HandleInvencibleBlinkinhEffectOver;
            input.OnShotPerformed -= HandleShotPerformed;
        }
    }
}