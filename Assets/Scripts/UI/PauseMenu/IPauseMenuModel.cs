using LeandroExhumed.UI.Navigation;

namespace LeandroExhumed.SpaceChaos.UI.PauseMenu
{
    public interface IPauseMenuModel : INavigableModel
    {
        void ShowRestartConfirmationModal ();
        void OpenInstructionScreen ();
        void ShowQuitToMainMenuConfirmationModal ();
    }
}