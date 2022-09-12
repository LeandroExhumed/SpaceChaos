using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOFacade : MonoBehaviour, IDamageableModel, IRouteMovement
    {
        public event Action<DeathInfo> OnDeath
        {
            add => health.OnDeath += value;
            remove => health.OnDeath -= value;
        }
        public event Action OnResurrection
        {
            add => health.OnResurrection += value;
            remove => health.OnResurrection -= value;
        }
        public event Action OnLeaving
        {
            add => routeMovement.OnLeaving += value;
            remove => routeMovement.OnLeaving -= value;
        }

        private IRouteMovement routeMovement;
        private IDamageableModel health;
        private IController controller;

        [Inject]
        public void Constructor (IRouteMovement routeMovement, IDamageableModel health, IController controller)
        {
            this.routeMovement = routeMovement;
            this.health = health;
            this.controller = controller;
        }

        private void Start ()
        {
            controller.Setup();
        }

        public void Initialize (Vector3 position) => routeMovement.Initialize(position);

        public void Tick () => routeMovement.Tick();

        public void TakeDamage () => health.TakeDamage();

        public void Resurrect () => health.Resurrect();

        private void OnDestroy ()
        {
            controller.Dispose();
        }       

        public class Factory : PlaceholderFactory<UFOFacade> { }
    }
}