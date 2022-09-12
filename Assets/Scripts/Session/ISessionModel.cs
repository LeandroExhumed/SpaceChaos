using System;

namespace LeandroExhumed.SpaceChaos.Session
{
    public interface ISessionModel : IDisposable
    {
        int CurrentStage { get; }

        event Action OnNewStageStarted;
        event Action OnStageCompleted;

        void Initialize ();
        void Tick ();
    }
}