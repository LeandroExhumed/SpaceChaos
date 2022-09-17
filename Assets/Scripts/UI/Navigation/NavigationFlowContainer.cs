using Zenject;

namespace LeandroExhumed.UI.Navigation
{
    public class NavigationFlowContainer : MonoInstaller
    {
        public override void InstallBindings ()
        {
            Container.Bind<INavigationFlowModel>().To<NavigationFlowModel>().AsSingle();
            Container.Bind<NavigationFlowController>().AsSingle();
        }
    }
}