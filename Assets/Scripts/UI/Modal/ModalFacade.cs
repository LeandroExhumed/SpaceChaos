using LeandroExhumed.UI.Navigation;
using System;
using Zenject;

namespace LeandroExhumed.UI.Modal
{
    public class ModalFacade : NavigableFacade, IModalModel
    {
        public event Action<string, string> OnSetup
        {
            add => model.OnSetup += value;
            remove => model.OnSetup -= value;
        }

        private IModalModel model;

        [Inject]
        public void Constructor (IModalModel model, ModalController controller)
        {
            base.Constructor(model, controller);
            this.model = model;
        }

        public void Setup (string title, string message, Action onConfirm, Action onCancel = null)
            => model.Setup(title, message, onConfirm, onCancel);

        public void Confirm () => model.Confirm();

        public void Cancel () => model.Cancel();
    }
}