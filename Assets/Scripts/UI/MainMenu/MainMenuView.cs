using LeandroExhumed.UI.Navigation;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace LeandroExhumed.SpaceChaos.UI.MainMenu
{
    public class MainMenuView : NavigableView
    {
        public event Action OnPlayButtonClick;
        public event Action OnInstructionsButtonClick;

        [SerializeField]
        private Button playButton;
        [SerializeField]
        private Button instructionsButton;

        private void Awake ()
        {
            playButton.onClick.AddListener(() => OnPlayButtonClick?.Invoke());
            instructionsButton.onClick.AddListener(() => OnInstructionsButtonClick?.Invoke());
        }
    }
}
