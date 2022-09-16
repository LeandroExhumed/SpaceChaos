using LeandroExhumed.UI.Modal;
using LeandroExhumed.UI.Navigation;
using System;

namespace LeandroExhumed.SpaceChaos.UI.PauseMenu
{
    public class PauseMenuModel : NavigableModel, IPauseMenuModel
    {
        private const string RESTART_CONFIRMATION_TITLE = "RESTART";
        private const string RESTART_CONFIRMATION_MESSAGE = "ARE YOU SURE YOU WANT TO RESTART CURRENT GAME?";
        private const string QUIT_TO_MAIN_MENU_CONFIRMATION_TITLE = "MAIN MENU";
        private const string QUIT_TO_MAIN_MENU_CONFIRMATION_MESSAGE = "ARE YOU SURE YOU WANT TO QUIT TO MAIN MENU?";

        private readonly INavigationFlowModel navigationFlow;
        private readonly INavigableModel instructionScreen;
        private readonly IModalModel modal;

        private readonly Pause pause;

        public PauseMenuModel (
            INavigationFlowModel navigationFlow,
            INavigableModel instructionScreen,
            IModalModel modal,
            Pause pause)
        {
            this.navigationFlow = navigationFlow;
            this.instructionScreen = instructionScreen;
            this.modal = modal;
            this.pause = pause;
        }

        public void Resume ()
        {
            pause.Execute();
        }

        public override bool Back ()
        {
            pause.Execute();
            return base.Back();
        }

        public void OpenInstructionScreen ()
        {
            navigationFlow.OpenScreen(instructionScreen);
        }

        public void ShowRestartConfirmationModal ()
        {
            ShowModal(RESTART_CONFIRMATION_TITLE, RESTART_CONFIRMATION_MESSAGE, Restart);
        }

        public void ShowQuitToMainMenuConfirmationModal ()
        {
            ShowModal(QUIT_TO_MAIN_MENU_CONFIRMATION_TITLE, QUIT_TO_MAIN_MENU_CONFIRMATION_MESSAGE, QuitToMainMenu);
        }

        private void Restart () => SceneLoader.ReloadScene();

        private void QuitToMainMenu () => SceneLoader.LoadMainMenu();

        private void ShowModal (string title, string message, Action onConfirm, Action onCancel = null)
        {
            modal.Setup(title, message, onConfirm, onCancel);
            navigationFlow.OpenScreen(modal);
        }
    }
}