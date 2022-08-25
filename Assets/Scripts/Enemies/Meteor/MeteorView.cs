using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorView : MonoBehaviour
    {
        public event Action<Collider> OnCollision;
        private GameObject parent;

        private void Awake ()
        {
            parent = transform.parent.gameObject;
        }

        public void Destroy () => Destroy(parent);

        private void OnCollisionEnter (Collision collision)
        {
            OnCollision?.Invoke(collision.collider);
        }
    }
}