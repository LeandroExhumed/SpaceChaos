using System;

namespace LeandroExhumed.SpaceChaos.Common
{
    public interface IShooterModel
    {
        event Action OnShot;

        void Shot ();
    }
}