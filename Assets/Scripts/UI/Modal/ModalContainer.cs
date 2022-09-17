using Zenject;

namespace LeandroExhumed.UI.Modal
{
    public class ModalContainer : MonoInstaller
    {
        public override void InstallBindings ()
        {
            Container.Bind<IModalModel>().To<ModalModel>().AsSingle();
            Container.Bind<ModalController>().AsSingle();
            Container.BindInstance(GetComponent<ModalView>()).AsSingle();
        }
    }
}