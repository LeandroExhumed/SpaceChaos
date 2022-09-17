using System;

namespace LeandroExhumed.UI.Navigation
{
    public interface INavigableModel
    {
        event Action OnOpened;
        event Action OnClosed;
        event Action OnBackRequested;
        event Action<bool> OnContentDisplayStatusChanged;

        void Open ();
        void Close ();
        bool Back ();
        void SetContentActive (bool active);
    }
}