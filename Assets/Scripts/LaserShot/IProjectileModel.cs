using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Pooling;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public interface IProjectileModel : ILaunchableModel, IPoolable
    {
        void HandleCollision (Collider colider);
    }
}