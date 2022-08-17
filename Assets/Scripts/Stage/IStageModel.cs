using LeandroExhumed.SpaceChaos.Common.Damage;
using System;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public interface IStageModel
    {
        event Action OnEnd;
        event Action OnGameOver;

        void Initialize (int startAsteroidsAmount);
        void Begin ();
        void Tick ();
        void HandleShipDeath (IDamageableModel ship);
        void End ();
    }
}