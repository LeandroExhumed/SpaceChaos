using LeandroExhumed.SpaceChaos.Services;
using LeandroExhumed.UI.Navigation;

namespace LeandroExhumed.SpaceChaos.UI.MainMenu
{
    public class MainMenuModel : NavigableModel, IMainMenuModel
    {
        private readonly INavigationFlowModel navigationFlow;
        private readonly INavigableModel instructionScreen;

        public MainMenuModel (INavigationFlowModel navigationFlow, INavigableModel instructionScreen)
        {
            this.navigationFlow = navigationFlow;
            this.instructionScreen = instructionScreen;

            navigationFlow.SetInitialElement(this);
        }

        public void Play () => SceneLoader.LoadGameplayScene();

        public void OpenInstructionScreen ()
        {
            navigationFlow.OpenScreen(instructionScreen);
        }
    }
}
