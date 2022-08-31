using System;
using UnityEngine;

namespace LeandroExhumed.UI.Navigation
{
    public class NavigableFacade : MonoBehaviour, INavigableModel
    {
        public event Action OnOpened
        {
            add => model.OnOpened += value;
            remove => model.OnOpened -= value;
        }
        public event Action OnClosed
        {
            add => model.OnClosed += value;
            remove => model.OnClosed -= value;
        }
        public event Action OnBackRequested
        {
            add => model.OnBackRequested += value;
            remove => model.OnBackRequested -= value;
        }
        public event Action<bool> OnContentDisplayStatusChanged
        {
            add => model.OnContentDisplayStatusChanged += value;
            remove => model.OnContentDisplayStatusChanged -= value;
        }

        private INavigableModel model;
        private IController controller;

        protected void Constructor (INavigableModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;

            controller.Setup();
        }

        public void Open () => model.Open();

        public void Close () => model.Close();

        public bool Back () => model.Back();

        public void SetContentActive (bool active) => model.SetContentActive(active);

        private void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}