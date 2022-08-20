using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Input;
using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class ShipFacade : MonoBehaviour, IMovementModel, IShooterModel, IDamageableModel
    {
        public event Action<bool> OnThrusterNeedChanged
        {
            add => movement.OnThrusterNeedChanged += value;
            remove => movement.OnThrusterNeedChanged -= value;
        }
        public event Action OnShot
        {
            add => shooter.OnShot += value;
            remove => shooter.OnShot -= value;
        }
        public event Action<IDamageableModel> OnDeath
        {
            add => health.OnDeath += value;
            remove => health.OnDeath -= value;
        }
        public event Action OnResurrection
        {
            add => health.OnResurrection += value;
            remove => health.OnResurrection -= value;
        }

        public int InstanceID => health.InstanceID;

        private IMovementModel movement;
        private IShooterModel shooter;
        private IDamageableModel health;
        private IController controller;

        [Inject]
        public void Constructor (
            IMovementModel movement,
            IShooterModel shooter,
            IDamageableModel health,
            ILifeModel life,
            IScoreModel score,
            IController controller,
            IInput input)
        {
            this.movement = movement;
            this.shooter = shooter;
            this.health = health;
            this.controller = controller;

            controller.Setup();

            life.Initialize(3);
            score.Initialize();
            input.SetActive(true);
        }

        public void Steer (float direction) => movement.Steer(direction);

        public void Thrust (float input) => movement.Thrust(input);
        
        public void Stop () => movement.Stop();

        public void Reset () => movement.Reset();
        
        public void Shot () => shooter.Shot();
        
        public void TakeDamage () => health.TakeDamage();
        
        public void Resurrect () => health.Resurrect();

        private void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}