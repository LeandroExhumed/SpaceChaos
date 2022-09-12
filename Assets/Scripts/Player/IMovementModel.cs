using LeandroExhumed.SpaceChaos.Common;
using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public interface IMovementModel : IOffscreenMovementModel
    {
        event Action<bool> OnThrusterNeedChanged;

        void Steer (float direction);
        void Thrust (float input);
        void Stop ();
        void Reset ();
    }
}