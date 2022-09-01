using System;

namespace LeandroExhumed.SpaceChaos.UI.GameOverScreen
{
    public interface IGameOverMenuModel
    {
        event Action<int, int> OnSetup;

        void Setup (int points);
        void QuitToMainMenu ();
    }
}