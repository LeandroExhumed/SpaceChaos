using LeandroExhumed.UI.Navigation;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.UI.MainMenu
{
    public class MainMenuController : NavigableController
    {
        private new readonly IMainMenuModel model;
        private new readonly MainMenuView view;

        public MainMenuController (IMainMenuModel model, MainMenuView view) : base (model, view)
        {
            this.model = model;
            this.view = view;
        }

        public override void Setup ()
        {
            base.Setup();

            view.OnPlayButtonClick += HandlePlayButtonClick;
            view.OnInstructionsButtonClick += HandleInstructionsButtonClick;
        }

        private void HandlePlayButtonClick ()
        {
            model.Play();
        }

        private void HandleInstructionsButtonClick ()
        {
            model.OpenInstructionScreen();
        }

        public override void Dispose ()
        {
            base.Dispose();

            view.OnPlayButtonClick -= HandlePlayButtonClick;
            view.OnInstructionsButtonClick -= HandleInstructionsButtonClick;
        }
    }
}