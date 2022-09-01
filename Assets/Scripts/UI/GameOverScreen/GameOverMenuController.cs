namespace LeandroExhumed.SpaceChaos.UI.GameOverScreen
{
    public class GameOverMenuController : IController
    {
        private readonly IGameOverMenuModel model;
        private readonly GameOverMenuView view;

        public GameOverMenuController (IGameOverMenuModel model, GameOverMenuView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Setup ()
        {
            model.OnSetup += HandleSetup;
            view.OnConfirmButtonClick += HandleConfirmButtonClick;
        }

        private void HandleSetup (int currentScore, int bestScore)
        {
            view.SetCurrentScoreText(currentScore);
            view.SetBestScoreText(bestScore);
            view.Show();
        }

        private void HandleConfirmButtonClick ()
        {
            model.QuitToMainMenu();
        }

        public void Dispose ()
        {
            model.OnSetup -= HandleSetup;
            view.OnConfirmButtonClick -= HandleConfirmButtonClick;
        }
    }
}