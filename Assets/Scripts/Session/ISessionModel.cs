using System;

namespace LeandroExhumed.SpaceChaos.Session
{
    public interface ISessionModel : IDisposable
    {
        int CurrentStage { get; }

        event Action OnNewStageStarted;
        event Action OnStageCompleted;
        event Action OnGameOver;

        void Initialize ();
        void Begin ();
        void Tick ();
    }
}