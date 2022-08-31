using System;
using UnityEngine;
using UnityEngine.UI;

namespace LeandroExhumed.UI.Navigation
{
    public class NavigableView : MonoBehaviour
    {
        public event Action OnBackButtonClick;

        [SerializeField]
        private Selectable firstSelected;
        [SerializeField]
        protected Button backButton;

        [SerializeField]
        private GameObject content;

        protected virtual void OnEnable ()
        {
            if (backButton)
            {
                backButton.onClick.AddListener(HandleBackButtonClicked);
            }
        }

        public void Open ()
        {
            if (firstSelected)
            {
                firstSelected.Select();
            }
            gameObject.SetActive(true);
        }

        public void SetContentActive (bool active)
        {
            if (content)
            {
                content.SetActive(active);
            }
            else
            {
                gameObject.SetActive(active);
            }
        }

        public void Close ()
        {
            gameObject.SetActive(false);
        }

        private void HandleBackButtonClicked ()
        {
            OnBackButtonClick?.Invoke();
        }

        private void OnDisable ()
        {
            if (backButton)
            {
                backButton.onClick.RemoveListener(HandleBackButtonClicked);
            }
        }
    }
}