using LeandroExhumed.UI.Navigation;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.UI.PauseMenu
{
    public class PauseMenuContainer : MonoInstaller
    {
        [SerializeField]
        private NavigableFacade instructionsScreen;

        public override void InstallBindings ()
        {
            ResolveMVC();

            Container.Bind<INavigableModel>().FromInstance(instructionsScreen).AsSingle();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IPauseMenuModel>().To<PauseMenuModel>().AsSingle();
            Container.Bind<IController>().To<PauseMenuController>().AsSingle();
            Container.BindInstance(GetComponent<PauseMenuView>()).AsSingle();
        }
    }
}