using Zenject;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageContainer : MonoInstaller
    {
        public override void InstallBindings ()
        {
            ResolveMVC();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IStageModel>().To<StageModel>().AsSingle();
            Container.Bind<IController>().To<StageController>().AsSingle();
        }
    }
}