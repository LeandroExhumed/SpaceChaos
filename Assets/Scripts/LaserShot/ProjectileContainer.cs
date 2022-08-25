using LeandroExhumed.SpaceChaos.Common;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public class ProjectileContainer : MonoInstaller
    {
        [SerializeField]
        private float speed = 50f;
        [SerializeField]
        private int[] targetLayers;

        public override void InstallBindings ()
        {
            Container.BindInstance(speed).AsSingle();
            Container.BindInstance(targetLayers).AsSingle();
            ResolveMVC();
            ResolveComponents();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IProjectileModel>().To<ProjectileModel>().AsSingle();
            Container.Bind<IController>().To<ProjectileController>().AsSingle();
            Container.BindInstance(GetComponentInChildren<ProjectileView>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<OffscreenDetector>()).AsSingle();
        }

        private void ResolveComponents ()
        {
            Container.BindInstance(transform).AsSingle();
            Container.BindInstance(GetComponent<Rigidbody>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<Collider>()).AsSingle();
        }
    } 
}