using System;

namespace LeandroExhumed.SpaceChaos.Session
{
    public interface ISessionModel : IDisposable
    {
        event Action OnNewStageStarted;
        event Action OnStageEnded;

        void Initialize ();
    }
}