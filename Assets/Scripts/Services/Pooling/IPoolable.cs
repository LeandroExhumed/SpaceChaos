using System;

namespace LeandroExhumed.SpaceChaos.Services.Pooling
{
    public interface IPoolable
    {
        event Action OnReused;
        event Action OnDestroyed;

        void Reuse ();
        void Destroy ();

        public class Factory : Zenject.PlaceholderFactory<IPoolable> { }
    }
}