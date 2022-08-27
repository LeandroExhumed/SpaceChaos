using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Pooling;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class ShipContainer : MonoInstaller
    {
        [SerializeField]
        private Transform[] weapons;
        [SerializeField]
        private PoolableObject projectilePrefab;

        public override void InstallBindings ()
        {
            ResolveMVC();
            Container.Bind<IInput>().To<PlayerInput>().AsSingle();
            ResolveComponents();
            ResolveWeapons();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IMovementModel>().To<MovementModel>().AsSingle();
            Container.Bind<IShooterModel>().To<ShooterModel>().AsSingle();
            Container.Bind<IDamageableModel>().To<Health>().AsSingle();
            Container.Bind<IController>().To<PlayerController>().AsSingle();
            Container.BindInstance(GetComponentInChildren<PlayerView>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<OffscreenDetector>()).AsSingle();
        }

        private void ResolveComponents ()
        {
            Container.BindInstance(transform).AsSingle();
            Container.BindInstance(GetComponent<Rigidbody>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<Collider>()).AsSingle();
        }

        private void ResolveWeapons ()
        {
            Container.BindInstance(weapons).AsSingle();
            Container.Bind<PoolableObject>().FromInstance(projectilePrefab).AsSingle();
            Container.BindFactory<PoolableObject, PoolableObject.Factory>()
                .FromComponentInNewPrefab(projectilePrefab);
        }
    }
}