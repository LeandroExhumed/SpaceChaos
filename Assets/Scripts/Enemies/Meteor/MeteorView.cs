using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorView : MonoBehaviour
    {
        public event Action<Collider> OnCollision;

        public void Destroy () => Destroy(gameObject);

        private void OnCollisionEnter (Collision collision)
        {
            OnCollision?.Invoke(collision.collider);
        }
    }
}