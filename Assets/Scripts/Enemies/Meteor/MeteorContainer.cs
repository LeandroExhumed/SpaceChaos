using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorContainer : MonoInstaller
    {
        [SerializeField]
        private float speed = 50f;
        [SerializeField]
        private int rewardXP = 80;

        public override void InstallBindings ()
        {
            ResolveMVC();
            Container.BindInstance(rewardXP).AsSingle();
            Container.BindInstance(speed).AsSingle();
            ResolveComponents();
        }

        private void ResolveMVC ()
        {
            Container.Bind<ILaunchableModel>().To<LaunchableModel>().AsSingle();
            Container.Bind<IOffscreenMovementModel>().To<OffscreenMovementModel>().AsSingle();
            Container.Bind<IOffscreenDetectorModel>().To<OffscreenDetectorModel>().AsSingle();
            Container.Bind<ISplittableModel>().To<SplittingModel>().AsSingle();
            Container.Bind<IDamageableModel>().To<EnemyHealth>().AsSingle();
            Container.Bind<IController>().To<MeteorController>().AsSingle();
            Container.BindInstance(GetComponentInChildren<MeteorView>()).AsSingle();
        }

        private void ResolveComponents ()
        {
            Container.BindInstance(transform).AsSingle();
            Container.BindInstance(GetComponentInChildren<Rigidbody>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<Collider>()).AsSingle();
        }
    } 
}