using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Pooling;
using LeandroExhumed.SpaceChaos.Session;
using LeandroExhumed.UI.Modal;
using LeandroExhumed.UI.Navigation;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class ApplicationContainer : MonoInstaller
    {
        [SerializeField]
        private SessionFacade session;

        [SerializeField]
        private NavigationFlowFacade navigationFlow;
        [SerializeField]
        private ModalFacade modal;
        [SerializeField]
        private NavigableFacade pauseMenu;

        public override void InstallBindings ()
        {
            Container.Bind<Pause>().AsSingle();
            Container.Bind<Pool>().AsSingle();
            Container.Bind<AudioProvider>().AsSingle();
            Container.BindInstance(Camera.main).AsSingle();

            Container.Bind<PlayerActions>().AsSingle();
            Container.Bind<IInput>().To<PlayerInput>().AsSingle();

            Container.Bind<ISessionModel>().FromInstance(session).AsSingle();

            Container.BindInstance(GetComponent<MonoBehaviour>()).AsSingle();

            Container.Bind<INavigationFlowModel>().FromInstance(navigationFlow).AsSingle();
            Container.Bind<IModalModel>().FromInstance(modal).AsSingle();
            Container.Bind<INavigableModel>().FromInstance(pauseMenu).AsSingle();
        }
    }
}