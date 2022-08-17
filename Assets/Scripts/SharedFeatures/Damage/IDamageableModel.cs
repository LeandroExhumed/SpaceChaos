using System;

namespace LeandroExhumed.SpaceChaos.Common.Damage
{
    public interface IDamageableModel
    {
        event Action<IDamageableModel> OnDeath;
        event Action OnResurrection;

        int InstanceID { get; }

        void TakeDamage ();
        void Resurrect ();
    }
}