using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorFacade : MonoBehaviour, ILaunchableModel, IDamageableModel
    {
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

        private ILaunchableModel launchable;
        private IDamageableModel health;
        private IController controller;

        [Inject]
        public void Constructor (ILaunchableModel launchable, IDamageableModel health, IController controller)
        {
            this.launchable = launchable;
            this.health = health;
            this.controller = controller;

            controller.Setup();
        }

        public void Initialize (Vector3 position, Quaternion rotation, Collider owner = null)
            => launchable.Initialize(position, rotation, owner);

        public void GetLaunched () => launchable.GetLaunched();

        public void TakeDamage () => health.TakeDamage();

        public void Resurrect () => health.Resurrect();

        private void OnDestroy ()
        {
            controller.Dispose();
        }

        public class Factory : PlaceholderFactory<MeteorFacade> { }
    }
}