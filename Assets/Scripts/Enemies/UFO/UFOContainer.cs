using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Player;
using LeandroExhumed.SpaceChaos.Pooling;
using LeandroExhumed.SpaceChaos.Session;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOContainer : MonoInstaller
    {
        [SerializeField]
        private AutoShotingType autoShotingType;

        [SerializeField]
        private float gunRotationSpeed = 8f;
        [SerializeField]
        private int rewardXP = 80;

        [SerializeField]
        private Transform[] weapons;
        [SerializeField]
        private PoolableObject projectilePrefab;

        private Transform ship;
        private ISessionModel session;

        [Inject]
        public void Constructor (ISessionModel session, ShipFacade ship)
        {
            this.ship = ship.transform;
            this.session = session;
        }

        public override void InstallBindings ()
        {
            ResolveMVC();
            Container.BindInstance(gunRotationSpeed * session.CurrentStage).AsSingle();
            Container.BindInstance(rewardXP).AsSingle();
            ResolveComponents();
            ResolveWeapons();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IRouteMovement>().To<RouteMovement>().AsSingle();
            Container.Bind<IOffscreenDetectorModel>().To<OffscreenDetectorModel>().AsSingle();
            Container.Bind<IShooterModel>().To<ShooterModel>().AsSingle();
            switch (autoShotingType)
            {
                case AutoShotingType.Random:
                    Container.Bind<IAutoShotingModel>().To<RandomShotingModel>().AsSingle();
                    break;
                default:
                    Container.BindInstance(ship).AsCached().WhenInjectedInto<PreciseShotingModel>();
                    Container.Bind<IAutoShotingModel>().To<PreciseShotingModel>().AsCached();
                    break;
            }
            Container.Bind<IDamageableModel>().To<EnemyHealth>().AsSingle();
            Container.Bind<IController>().To<UFOController>().AsSingle();
            Container.BindInstance(GetComponentInChildren<UFOView>()).AsSingle();
        }

        private void ResolveComponents ()
        {
            Container.BindInstance(transform).AsCached();
            Container.BindInstance(GetComponentInChildren<Rigidbody>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<Collider>()).AsSingle();
        }

        private void ResolveWeapons ()
        {
            Container.BindInstance(weapons).AsCached();
            Container.Bind<PoolableObject>().FromInstance(projectilePrefab).AsSingle();
            Container.BindFactory<PoolableObject, PoolableObject.Factory>()
                .FromComponentInNewPrefab(projectilePrefab);
        }
    }

    public enum AutoShotingType
    {
        Random,
        Precise
    }
}