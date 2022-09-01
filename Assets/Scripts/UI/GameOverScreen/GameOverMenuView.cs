using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeandroExhumed.SpaceChaos.UI.GameOverScreen
{
    public class GameOverMenuView : MonoBehaviour
    {
        public event Action OnConfirmButtonClick;

        [SerializeField]
        private TextMeshProUGUI currentScoreLabel;
        [SerializeField]
        private TextMeshProUGUI highestScoreLabel;

        [SerializeField]
        private Button confirmButton;

        private void Awake ()
        {
            confirmButton.onClick.AddListener(() => OnConfirmButtonClick?.Invoke());
        }

        public void SetCurrentScoreText (int points)
        {
            currentScoreLabel.text = points.ToString();
        }
        
        public void SetBestScoreText (int points)
        {
            highestScoreLabel.text = points.ToString();
        }

        public void Show ()
        {
            gameObject.SetActive(true);
        }
    }
}