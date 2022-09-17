using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Services.Pooling
{
    public class PoolableObject : MonoBehaviour, IPoolable
    {
        public virtual event Action OnReused;
        public virtual event Action OnDestroyed;

        public virtual void Reuse () { }

        public virtual void Destroy ()
        {
            gameObject.SetActive(false);
        }

        public class Factory : Zenject.PlaceholderFactory<PoolableObject> { }
    }
}