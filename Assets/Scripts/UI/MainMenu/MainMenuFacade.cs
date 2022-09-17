using LeandroExhumed.UI.Navigation;
using Zenject;

namespace LeandroExhumed.SpaceChaos.UI.MainMenu
{
    public class MainMenuFacade : NavigableFacade, IMainMenuModel
    {
        private IMainMenuModel model;
        private IController controller;

        [Inject]
        public void Constructor (IMainMenuModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;

            controller.Setup();
        }

        public void Play () => model.Play();

        public void OpenInstructionScreen () => model.OpenInstructionScreen();

        private void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}