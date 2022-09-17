using LeandroExhumed.SpaceChaos.Common;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class MovementModel : OffscreenMovementModel, IMovementModel
    {
        public event Action<bool> OnThrusterNeedChanged;

        private float thrusterMinVelocity = 0.3f;

        private Vector3 startPosition;
        private Quaternion startRotation;

        private readonly PlayerData data;
        private readonly Transform transform;
        private readonly Rigidbody rigidbody;

        public MovementModel (
            PlayerData data,
            IOffscreenDetectorModel offscreenDetector,
            Transform transform,
            Rigidbody rigidbody) : base(offscreenDetector, transform, rigidbody)
        {
            this.transform = transform;
            this.rigidbody = rigidbody;

            startPosition = transform.position;
            startRotation = transform.rotation;
            this.data = data;
        }

        public void Steer (float direction)
        {
            transform.Rotate(0, direction * data.SteeringSpeed * Time.deltaTime, 0);
        }

        public void Thrust (float input)
        {
            if (input > 0)
            {
                rigidbody.AddForce(data.ThrustingForce * input * transform.forward);
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