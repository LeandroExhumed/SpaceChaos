using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOContainer : MonoInstaller
    {
        [SerializeField]
        private int rewardXP = 80;

        public override void InstallBindings ()
        {
            ResolveMVC();
            Container.BindInstance(rewardXP).AsSingle();
            ResolveComponents();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IRouteMovement>().To<RouteMovement>().AsSingle();
            Container.Bind<IDamageableModel>().To<EnemyHealth>().AsSingle();
            Container.Bind<IController>().To<UFOController>().AsSingle();
            Container.BindInstance(GetComponentInChildren<UFOView>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<OffscreenDetector>()).AsSingle();
        }

        private void ResolveComponents ()
        {
            Container.BindInstance(transform).AsSingle();
            Container.BindInstance(GetComponentInChildren<Rigidbody>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<Collider>()).AsSingle();
        }
    }
}