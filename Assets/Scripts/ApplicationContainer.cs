using LeandroExhumed.SpaceChaos.Player;
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
            Container.Bind<IAsteroindSpawningModel>().To<AsteroindSpawningModel>().AsSingle();
            Container.Bind<ILifeModel>().To<LifeModel>().AsSingle();
            Container.Bind<IStageModel>().FromInstance(stage).AsSingle();
        }
    }
}