using LeandroExhumed.UI.Navigation;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace LeandroExhumed.SpaceChaos.UI.PauseMenu
{
    public class PauseMenuView : NavigableView
    {
        public event Action OnRestartButtonClick;
        public event Action OnInstructionsButtonClick;
        public event Action OnMainMenuButtonClick;

        [SerializeField]
        private Button restartButton;
        [SerializeField]
        private Button instructionsButton;
        [SerializeField]
        private Button mainMenuButton;

        private void Awake ()
        {
            restartButton.onClick.AddListener(() => OnRestartButtonClick?.Invoke());
            instructionsButton.onClick.AddListener(() => OnInstructionsButtonClick?.Invoke());
            mainMenuButton.onClick.AddListener(() => OnMainMenuButtonClick?.Invoke());
        }
    }
}