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

        [SerializeField]
        private ProjectileData data;

        public override void InstallBindings ()
        {
            Container.BindInstance(data.Speed).AsSingle();
            Container.BindInstance(targetLayers).AsSingle();
            ResolveMVC();
            ResolveComponents();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IProjectileModel>().To<ProjectileModel>().AsSingle();
            Container.Bind<IOffscreenDetectorModel>().To<OffscreenDetectorModel>().AsSingle();
            Container.Bind<IController>().To<ProjectileController>().AsSingle();
            Container.BindInstance(GetComponentInChildren<ProjectileView>()).AsSingle();
        }

        private void ResolveComponents ()
        {
            Container.BindInstance(transform).AsSingle();
            Container.BindInstance(GetComponent<Rigidbody>()).AsSingle();
            Container.BindInstance(GetComponentInChildren<Collider>()).AsSingle();
        }
    } 
}