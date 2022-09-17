using System;

namespace LeandroExhumed.SpaceChaos.Common
{
    public interface IShooterModel : IDisposable
    {
        event Action OnShot;

        void Shot ();
    }
}