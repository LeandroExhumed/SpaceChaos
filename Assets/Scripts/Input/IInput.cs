using System;

namespace LeandroExhumed.SpaceChaos.Input
{
    public interface IInput
    {
        event Action OnShotPerformed;

        float Steer { get; }
        float Thrust { get; }

        void SetActive (bool value);
    }
}