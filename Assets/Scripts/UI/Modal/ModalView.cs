using LeandroExhumed.UI.Navigation;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeandroExhumed.UI.Modal
{
    public class ModalView : NavigableView
    {
        public event Action OnConfirmButtonClick;
        public event Action OnCancelButtonClick;

        [SerializeField]
        private TextMeshProUGUI titleText;
        [SerializeField]
        private TextMeshProUGUI messageText;

        [SerializeField]
        private Button confirmButton;
        [SerializeField]
        private Button cancelButton;

        private void Awake ()
        {
            confirmButton.onClick.AddListener(() => OnConfirmButtonClick?.Invoke());
            cancelButton.onClick.AddListener(() => OnCancelButtonClick?.Invoke());
        }

        public void SetTitle (string title)
        {
            titleText.text = title;
        }
        
        public void SetMessage (string message)
        {
            messageText.text = message;
        }
    }
}