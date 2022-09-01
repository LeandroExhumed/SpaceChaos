using System;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public interface IStageModel : IDisposable
    {
        event Action OnCompleted;

        void Initialize ();
        void Begin (int startAsteroidsAmount);
        void Tick ();
    }
}