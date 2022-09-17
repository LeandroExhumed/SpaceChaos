using System;

namespace LeandroExhumed.SpaceChaos.Common.Damage
{
    public interface IDamageableModel
    {
        event Action<DeathInfo> OnDeath;
        event Action OnResurrection;

        void TakeDamage ();
        void Resurrect ();
    }
}