using LeandroExhumed.SpaceChaos.Pooling;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public interface IProjectileModel : IPoolable
    {
        void Initialize (Vector3 position, Vector3 rotation);
        void GetLaunched ();
        void HandleCollision (Collider colider);
    }
}