using LeandroExhumed.UI.Navigation;
using System;

namespace LeandroExhumed.UI.Modal
{
    public interface IModalModel : INavigableModel
    {
        event Action<string, string> OnSetup;

        void Setup (string title, string message, Action onConfirm, Action onCancel = null);
        void Confirm ();
        void Cancel ();
    }
}