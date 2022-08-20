using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Player;
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

        public override void InstallBindings ()
        {
            Container.Bind<Pool>().AsSingle();
            Container.Bind<AudioProvider>().AsSingle();

            Container.Bind<PlayerActions>().AsSingle();

            Container.Bind<IAsteroindSpawningModel>().To<AsteroindSpawningModel>().AsSingle();            
            Container.Bind<IStageModel>().FromInstance(stage).AsSingle();
        }
    }
}