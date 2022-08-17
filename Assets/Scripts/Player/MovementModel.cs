using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class MovementModel
    {
        public event Action<bool> OnThrusterNeedChanged;

        private float speed = 300f;
        private float force = 5f;
        private float thrusterMinVelocity = 0.3f;

        private readonly Transform transform;
        private readonly Rigidbody rigidbody;

        public void Steer (float direction)
        {
            transform.Rotate(0, 0, -direction * speed * Time.deltaTime);
        }

        public void Thrust (float input)
        {
            if (input > 0)
            {
                rigidbody.AddForce(force * input * transform.up);
            }

            OnThrusterNeedChanged?.Invoke(rigidbody.velocity.magnitude >= thrusterMinVelocity);
        }

        public void Stop ()
        {
            rigidbody.velocity = Vector3.zero;
        }

        public void Reset ()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }
}