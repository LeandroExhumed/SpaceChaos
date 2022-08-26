using LeandroExhumed.SpaceChaos.Common;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class MovementModel : OffscreenMovementModel, IMovementModel
    {
        public event Action<bool> OnThrusterNeedChanged;

        private float speed = 300f;
        private float force = 5f;
        private float thrusterMinVelocity = 0.3f;

        private Vector3 startPosition;
        private Quaternion startRotation;

        private readonly Transform transform;
        private readonly Rigidbody rigidbody;

        public MovementModel (
            Transform transform,
            Rigidbody rigidbody,
            Camera camera) : base (transform, rigidbody, camera)
        {
            this.transform = transform;
            this.rigidbody = rigidbody;

            startPosition = transform.position;
            startRotation = transform.rotation;
        }

        public void Steer (float direction)
        {
            transform.Rotate(0, direction * speed * Time.deltaTime, 0);
        }

        public void Thrust (float input)
        {
            if (input > 0)
            {
                rigidbody.AddForce(force * input * transform.forward);
            }

            OnThrusterNeedChanged?.Invoke(rigidbody.velocity.magnitude >= thrusterMinVelocity);
        }

        public void Stop ()
        {
            rigidbody.velocity = Vector3.zero;
        }

        public void Reset ()
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}