using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorView : MonoBehaviour
    {
        public event Action<Collider> OnCollision;

        [SerializeField]
        private GameObject mesh;
        [SerializeField]
        private new Collider collider;

        [SerializeField]
        private GameObject explosion;

        private const float EXPLOSION_LIFETIME = 3;

        public void DisableCollider ()
        {
            collider.enabled = false;
        }

        public void DisableMesh ()
        {
            mesh.SetActive(false);
        }

        public void CreateDestructionVFX ()
        {
            Destroy(Instantiate(explosion, transform.position, explosion.transform.rotation), EXPLOSION_LIFETIME);
        }

        private void OnTriggerEnter (Collider other)
        {
            OnCollision?.Invoke(other);            
        }
    }
}