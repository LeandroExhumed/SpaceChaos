using LeandroExhumed.SpaceChaos.Audio;
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
        private ModalFacade modal;
        [SerializeField]
        private NavigableFacade pauseMenu;

        public override void InstallBindings ()
        {
            Container.Bind<Pause>().AsSingle();
            
            Container.BindInstance(Camera.main).AsSingle();

            Container.Bind<ISessionModel>().FromInstance(session).AsSingle();

            Container.BindInstance(GetComponent<MonoBehaviour>()).AsSingle();

            Container.Bind<IModalModel>().FromInstance(modal).AsSingle();
            Container.Bind<INavigableModel>().FromInstance(pauseMenu).AsSingle();
        }
    }
}