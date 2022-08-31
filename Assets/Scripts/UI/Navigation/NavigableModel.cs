using System;

namespace LeandroExhumed.UI.Navigation
{
    public class NavigableModel : INavigableModel
    {
        public event Action OnOpened;
        public event Action OnClosed;
        public event Action OnBackRequested;
        public event Action<bool> OnContentDisplayStatusChanged;

        public virtual void Open ()
        {
            OnOpened?.Invoke();
        }

        public void Close ()
        {
            OnClosed?.Invoke();
        }

        public virtual bool Back ()
        {
            OnBackRequested?.Invoke();

            return true;
        }

        public void SetContentActive (bool active)
        {
            OnContentDisplayStatusChanged?.Invoke(active);
        }
    }
}