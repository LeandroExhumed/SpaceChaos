using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.UI.Navigation
{
    public class NavigationFlowFacade : MonoBehaviour, INavigationFlowModel
    {
        public event Action OnNavigation
        {
            add => model.OnNavigation += value;
            remove => model.OnNavigation -= value;
        }

        public INavigableModel CurrentElement => model.CurrentElement;

        private INavigationFlowModel model;
        private NavigationFlowController controller;

        [Inject]
        public void Constructor (INavigationFlowModel model, NavigationFlowController controller)
        {
            this.model = model;
            this.controller = controller;

            controller.Setup();
        }

        public void SetInitialElement (INavigableModel element) => model.SetInitialElement(element);

        public void OpenScreen (INavigableModel element) => model.OpenScreen(element);

        public void RequestBack () => model.RequestBack();

        private void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}