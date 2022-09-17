using Zenject;

namespace LeandroExhumed.UI.Navigation
{
    public class DefaultContainer : MonoInstaller
    {
        public override void InstallBindings ()
        {
            Container.Bind<INavigableModel>().To<NavigableModel>().AsSingle();
            Container.Bind<IController>().To<NavigableController>().AsSingle();
            Container.BindInstance(GetComponent<NavigableView>()).AsSingle();
        }
    }
}