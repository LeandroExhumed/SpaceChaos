using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOView : MonoBehaviour
    {
        public event Action OnUpdate;
        public event Action<Collider> OnCollision;

        [SerializeField]
        private GameObject explosion;

        private GameObject parent;

        private void Awake ()
        {
            parent = transform.parent.gameObject;
        }

        public void PlayExplosionVFX ()
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }

        public void Destroy () => Destroy(parent);

        private void Update ()
        {
            OnUpdate?.Invoke();
        }

        private void OnCollisionEnter (Collision collision)
        {
            OnCollision?.Invoke(collision.collider);
        }
    }
}