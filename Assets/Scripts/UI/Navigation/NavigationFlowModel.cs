using System;
using System.Collections.Generic;

namespace LeandroExhumed.UI.Navigation
{
    public class NavigationFlowModel : INavigationFlowModel
    {
        public event Action OnNavigation;

        public INavigableModel CurrentElement
        {
            get
            {
                if (navigableElements.Count > 0)
                {
                    return navigableElements.Peek();
                }

                return null;
            }
        }

        private readonly Stack<INavigableModel> navigableElements = new();

        public void OpenScreen (INavigableModel element)
        {
            NavigateTo(element);
            element.OnBackRequested += Back;
            SetCurrentElementContentActive(false);

            navigableElements.Push(element);
        }

        public void RequestBack ()
        {
            CurrentElement?.Back();
        }

        private void NavigateTo (INavigableModel element)
        {
            if (element != null)
            {
                element.Open();
            }

            OnNavigation?.Invoke();
        }

        private void Back ()
        {
            INavigableModel removed = navigableElements.Pop();
            removed.OnBackRequested -= Back;
            removed.Close();

            SetCurrentElementContentActive(true);
            NavigateTo(CurrentElement);
        }

        private void SetCurrentElementContentActive (bool active)
        {
            if (CurrentElement != null)
            {
                CurrentElement.SetContentActive(active);
            }
        }
    }
}