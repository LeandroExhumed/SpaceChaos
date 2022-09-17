using LeandroExhumed.UI.Navigation;
using System;

namespace LeandroExhumed.UI.Modal
{
    public class ModalModel : NavigableModel, IModalModel
    {
        public event Action<string, string> OnSetup;

        private event Action OnConfirm;
        private event Action OnCancel;

        public void Setup (string title, string message, Action onConfirm, Action onCancel = null)
        {
            OnConfirm = onConfirm;
            OnCancel = onCancel;

            OnSetup?.Invoke(title, message);
        }

        public void Confirm ()
        {
            OnConfirm?.Invoke();
        }

        public void Cancel ()
        {
            OnCancel?.Invoke();
        }
    }
}