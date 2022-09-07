using LeandroExhumed.UI.Navigation;

namespace LeandroExhumed.SpaceChaos.UI.MainMenu
{
    public interface IMainMenuModel : INavigableModel
    {
        void Play ();
        void OpenInstructionScreen ();
    }
}