using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    [CreateAssetMenu(fileName = "Projectile", menuName = "Projectile")]
    public class ProjectileData : ScriptableObject
    {
        public float Speed => speed;

        [SerializeField]
        private float speed = 500f;
    }
}