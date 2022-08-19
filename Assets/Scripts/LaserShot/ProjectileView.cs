using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public class ProjectileView : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEntered;

        private void OnTriggerEnter (Collider other)
        {
            OnTriggerEntered?.Invoke(other);
        }

        public void Destroy () => gameObject.SetActive(false);
    }
}