using System;

namespace LeandroExhumed.SpaceChaos.Input
{
    public interface IInput
    {
        event Action OnShotPerformed;
        event Action OnPausePerformed;

        float Steer { get; }
        float Thrust { get; }

        void SetActive (bool value);
    }
}