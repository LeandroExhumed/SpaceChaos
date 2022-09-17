using LeandroExhumed.SpaceChaos.Common.Damage;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies
{
    public class EnemyFacade : MonoBehaviour, IDamageableModel
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

        public string InstanceID;

        private IDamageableModel health;

        private IController controller;

        public void Constructor (string instanceID, IDamageableModel health, IController controller)
        {
            InstanceID = instanceID;
            this.health = health;
            this.controller = controller;

            controller.Setup();
        }

        public void TakeDamage () => health.TakeDamage();

        public void Resurrect () => health.Resurrect();

        protected virtual void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}