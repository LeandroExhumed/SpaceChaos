using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOFacade : EnemyFacade, IRouteMovement
    {        
        public event Action<string> OnLeaving
        {
            add => routeMovement.OnLeaving += value;
            remove => routeMovement.OnLeaving -= value;
        }

        private IRouteMovement routeMovement;
        private IShooterModel shooter;

        [Inject]
        public void Constructor (
            IRouteMovement routeMovement,
            IShooterModel shooter,
            string instanceID,
            IDamageableModel health,
            IController controller)
        {
            Constructor(instanceID, health, controller);

            this.routeMovement = routeMovement;
            this.shooter = shooter;
        }

        public void Initialize (Vector3 position) => routeMovement.Initialize(position);

        public void Tick () => routeMovement.Tick();

        protected override void OnDestroy ()
        {
            base.OnDestroy();
            shooter.Dispose();
        }       

        public class Factory : PlaceholderFactory<UFOFacade> { }
    }
}