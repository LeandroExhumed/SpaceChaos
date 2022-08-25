using LeandroExhumed.SpaceChaos.Pooling;
using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public class ProjectileFacade : PoolableObject, IProjectileModel
    {
        public override event Action OnReused
        {
            add => model.OnReused += value;
            remove => model.OnReused -= value;
        }
        public override event Action OnDestroyed
        {
            add => model.OnDestroyed += value;
            remove => model.OnDestroyed -= value;
        }

        private IProjectileModel model;
        private IController controller;

        [Inject]
        public void Constructor (IProjectileModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;

            controller.Setup();
        }
        public void Initialize (Vector3 position, Quaternion rotation, Collider owner = null)
            => model.Initialize(position, rotation, owner);

        public void GetLaunched () => model.GetLaunched();
        public void HandleCollision (Collider colider) => model.HandleCollision(colider);

        public override void Reuse () => model.Reuse();

        public override void Destroy () => model.Destroy();

        private void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}