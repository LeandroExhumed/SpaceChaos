using LeandroExhumed.UI.Navigation;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.UI.MainMenu
{
    public class MainMenuContainer : MonoInstaller
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
            Container.Bind<IMainMenuModel>().To<MainMenuModel>().AsSingle();
            Container.Bind<IController>().To<MainMenuController>().AsSingle();
            Container.BindInstance(GetComponent<MainMenuView>()).AsSingle();
        }
    }
}