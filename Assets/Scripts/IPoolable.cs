using System;

namespace LeandroExhumed.SpaceChaos.Pooling
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