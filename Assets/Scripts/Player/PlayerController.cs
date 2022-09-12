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
        private readonly IOffscreenDetectorModel offscreenDetector;
        private readonly IShooterModel shooter;
        private readonly IDamageableModel health;
        private readonly ILifeModel life;
        private readonly IScoreModel score;
        private readonly PlayerView view;
        private readonly PlayerUIView uiView;
        
        private readonly IInput input;
        private readonly AudioProvider audioProvider;

        public PlayerController (
            IMovementModel movement,
            IOffscreenDetectorModel offscreenDetector,
            IShooterModel shooter,
            IDamageableModel health,
            ILifeModel life,
            IScoreModel score,
            PlayerView view,
            PlayerUIView uiView,
            IInput input,
            AudioProvider audioProvider)
        {
            this.movement = movement;
            this.offscreenDetector = offscreenDetector;
            this.shooter = shooter;
            this.health = health;
            this.life = life;
            this.score = score;
            this.view = view;
            this.uiView = uiView;
            this.input = input;
            this.audioProvider = audioProvider;
        }

        public void Setup ()
        {
            movement.OnThrusterNeedChanged += HandleThrusterNeedChanged;
            shooter.OnShot += HandleShot;
            health.OnDeath += HandleDeath;
            health.OnResurrection += HandleResurrection;
            life.OnLifeChanged += HandleLifeChanged;
            score.OnScoreChanged += HandleScoreChanged;
            score.OnAdvancedScoreReached += HandleAdvancedScoreReached;
            view.OnUpdate += HandleUpdate;
            view.OnCollision += HandleCollision;
            view.OnInvencibleBlinkinhEffectOver += HandleInvencibleBlinkinhEffectOver;
            input.OnShotPerformed += HandleShotPerformed;
        }

        private void HandleLifeChanged (int life)
        {
            uiView.SyncLife(life);
        }

        private void HandleScoreChanged (int points)
        {
            uiView.SyncScore(points);
        }

        private void HandleAdvancedScoreReached ()
        {
            life.AddLife();
        }

        private void HandleThrusterNeedChanged (bool needed)
        {
            view.SetThrusterActive(needed);
        }

        private void HandleShot ()
        {
            audioProvider.PlayOneShot(SoundType.LaserShot);
        }

        private void HandleDeath (DeathInfo _)
        {
            view.SetColliderActive(false);
            view.DisableMeshes();
            view.PlayExplosionVFX();
            life.LoseLife();
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
            life.OnLifeChanged -= HandleLifeChanged;
            score.OnScoreChanged -= HandleScoreChanged;
            score.OnAdvancedScoreReached -= HandleAdvancedScoreReached;
            view.OnUpdate -= HandleUpdate;
            view.OnCollision -= HandleCollision;
            view.OnInvencibleBlinkinhEffectOver -= HandleInvencibleBlinkinhEffectOver;
            input.OnShotPerformed -= HandleShotPerformed;
        }
    }
}