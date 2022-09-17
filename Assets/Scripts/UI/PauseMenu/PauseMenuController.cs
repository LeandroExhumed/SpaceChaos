using LeandroExhumed.UI.Navigation;

namespace LeandroExhumed.SpaceChaos.UI.PauseMenu
{
    public class PauseMenuController : NavigableController
    {
        private new readonly IPauseMenuModel model;
        private new readonly PauseMenuView view;

        public PauseMenuController (IPauseMenuModel model, PauseMenuView view) : base(model, view)
        {
            this.model = model;
            this.view = view;
        }

        public override void Setup ()
        {
            base.Setup();

            view.OnRestartButtonClick += HandleRestartButtonClick;
            view.OnInstructionsButtonClick += HandleSettingsButtonClick;
            view.OnMainMenuButtonClick += HandleMainMenuButtonClick;
        }

        private void HandleRestartButtonClick ()
        {
            model.ShowRestartConfirmationModal();
        }

        private void HandleSettingsButtonClick ()
        {
            model.OpenInstructionScreen();
        }

        private void HandleMainMenuButtonClick ()
        {
            model.ShowQuitToMainMenuConfirmationModal();
        }

        public override void Dispose ()
        {
            base.Dispose();

            view.OnRestartButtonClick -= HandleRestartButtonClick;
            view.OnInstructionsButtonClick -= HandleSettingsButtonClick;
            view.OnMainMenuButtonClick -= HandleMainMenuButtonClick;
        }
    }
}