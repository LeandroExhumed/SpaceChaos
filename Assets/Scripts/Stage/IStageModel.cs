using System;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public interface IStageModel : IDisposable
    {
        event Action OnEnd;
        event Action OnGameOver;

        void Initialize ();
        void Begin (int startAsteroidsAmount);
        void Tick ();
        void End ();
    }
}