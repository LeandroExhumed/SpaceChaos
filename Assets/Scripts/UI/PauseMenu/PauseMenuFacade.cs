using LeandroExhumed.UI.Navigation;
using Zenject;

namespace LeandroExhumed.SpaceChaos.UI.PauseMenu
{
    public class PauseMenuFacade : NavigableFacade, IPauseMenuModel
    {
        private IPauseMenuModel model;

        [Inject]
        public void Constructor (IPauseMenuModel model, IController controller)
        {
            base.Constructor(model, controller);
            this.model = model;
        }

        public void OpenInstructionScreen () => model.OpenInstructionScreen();

        public void ShowQuitToMainMenuConfirmationModal () => model.ShowQuitToMainMenuConfirmationModal();

        public void ShowRestartConfirmationModal () => model.ShowRestartConfirmationModal();
    }
}