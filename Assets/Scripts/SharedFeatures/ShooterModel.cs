using LeandroExhumed.SpaceChaos.Pooling;
using LeandroExhumed.SpaceChaos.Projectile;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class ShooterModel : IShooterModel
    {
        public event Action OnShot;

        private const int POOL_SIZE = 20;

        private readonly Transform[] weapons;
        private readonly PoolableObject projectilePrefab;

        private readonly Pool pool;

        private readonly Collider collider;

        public ShooterModel (
            Transform[] weapons,
            PoolableObject projectilePrefab,
            PoolableObject.Factory projectileFactory,
            Pool pool,
            Collider collider)
        {
            this.weapons = weapons;
            this.projectilePrefab = projectilePrefab;
            this.pool = pool;

            pool.AddPool(projectilePrefab, POOL_SIZE, projectileFactory);
            this.collider = collider;
        }

        public void Shot ()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                ProjectileFacade projectile = pool.GetObject<ProjectileFacade>(projectilePrefab);
                projectile.Initialize(weapons[i].position, weapons[i].rotation, collider);
                projectile.GetLaunched();
                OnShot?.Invoke(); 
            }
        }
    }
}
