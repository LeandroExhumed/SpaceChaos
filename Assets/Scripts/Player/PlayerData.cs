using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Player
{
    [CreateAssetMenu(fileName = "Ship", menuName = "Ship")]
    public class PlayerData : ScriptableObject
    {
        public float SteeringSpeed => steeringSpeed;
        public float ThrustingForce => thrustingForce;
        
        [SerializeField]
        private float steeringSpeed = 300f;
        [SerializeField]
        private float thrustingForce = 5f;
    }
}