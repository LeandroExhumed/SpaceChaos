using System;

namespace LeandroExhumed.SpaceChaos.Common.Damage
{
    class Health : IDamageableModel
    {
        public event Action<IDamageableModel> OnDeath;
        public event Action OnResurrection;

        public int InstanceID { get; private set; }

        public Health (int instanceID)
        {
            InstanceID = instanceID;
        }

        public void TakeDamage ()
        {
            OnDeath?.Invoke(this);
        }

        public void Resurrect ()
        {
            OnResurrection?.Invoke();
        }
    }
}