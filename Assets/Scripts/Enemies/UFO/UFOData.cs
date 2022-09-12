using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    [CreateAssetMenu(fileName = "UFO", menuName = "Enemies/UFO")]
    public class UFOData : EnemyData
    {
        public float Speed => speed;
        public float FireRate => fireRate;
        public float GunRotationSpeed => gunRotationSpeed;

        [SerializeField]
        private float speed = 5f;
        [SerializeField]
        private float gunRotationSpeed = 5f;
        [SerializeField]
        private float fireRate = 1f;
    }
}