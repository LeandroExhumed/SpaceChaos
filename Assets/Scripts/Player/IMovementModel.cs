using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public interface IMovementModel
    {
        event Action<bool> OnThrusterNeedChanged;

        void Steer (float direction);
        void Thrust (float input);
        void Stop ();
        void Reset ();
        void Overflow ();
    }
}