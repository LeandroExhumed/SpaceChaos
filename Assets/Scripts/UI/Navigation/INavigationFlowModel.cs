using System;

namespace LeandroExhumed.UI.Navigation
{
    public interface INavigationFlowModel
    {
        event Action OnNavigation;
        INavigableModel CurrentElement { get; }

        void OpenScreen (INavigableModel element);
        void RequestBack ();
    }
}