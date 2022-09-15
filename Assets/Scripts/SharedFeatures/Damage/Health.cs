using System;

namespace LeandroExhumed.SpaceChaos.Common.Damage
{
    public class Health : IDamageableModel
    {
        public event Action<DeathInfo> OnDeath;
        public event Action OnResurrection;

        protected readonly string instanceID;

        public Health (string instanceID)
        {
            this.instanceID = instanceID;
        }

        public void TakeDamage ()
        {
            OnDeath?.Invoke(GetDeathInfo());
        }

        public void Resurrect ()
        {
            OnResurrection?.Invoke();
        }

        protected virtual DeathInfo GetDeathInfo ()
        {
            return new DeathInfo(instanceID);
        }
    }
}