using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Pooling;
using LeandroExhumed.SpaceChaos.Stage;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class ApplicationContainer : MonoInstaller
    {
        [SerializeField]
        private StageFacade stage;

        [SerializeField]
        private MeteorFacade meteorPrefab;

        public override void InstallBindings ()
        {
            Container.Bind<Pool>().AsSingle();
            Container.Bind<AudioProvider>().AsSingle();
            Container.BindInstance(Camera.main).AsSingle();

            Container.Bind<PlayerActions>().AsSingle();

            Container.BindFactory<MeteorFacade, MeteorFacade.Factory>()
                .FromComponentInNewPrefab(meteorPrefab);
            Container.Bind<IAsteroindSpawningModel>().To<AsteroindSpawningModel>().AsSingle();            
            Container.Bind<IStageModel>().FromInstance(stage).AsSingle();
        }
    }
}