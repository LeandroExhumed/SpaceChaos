using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class MainMenuSceneContainer : MonoInstaller
    {
        [SerializeField]
        private MeteorFacade[] meteors;

        public override void InstallBindings ()
        {
            Container.Bind<ILaunchableModel[]>().FromInstance(meteors).AsSingle();
            ResolveMeteor();
        }

        private void ResolveMeteor ()
        {
            Container.BindInstance(Camera.main).AsSingle();
            // TODO: Review the necessity of a new meteor entity.
            Container.BindFactory<MeteorFacade, MeteorFacade.Factory>()
                .FromComponentInNewPrefab(this);
            Container.Bind<MeteorFactory>().AsSingle();
        }
    }
}