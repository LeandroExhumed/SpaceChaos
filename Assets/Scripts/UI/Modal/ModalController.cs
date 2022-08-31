using LeandroExhumed.UI.Navigation;

namespace LeandroExhumed.UI.Modal
{
    public class ModalController : NavigableController
    {
        private new readonly IModalModel model;
        private new readonly ModalView view;

        public ModalController (IModalModel model, ModalView view) : base (model, view)
        {
            this.model = model;
            this.view = view;
        }

        public override void Setup ()
        {
            base.Setup();

            model.OnSetup += HandleSetup;
            view.OnConfirmButtonClick += HandleConfirmButtonClick;
            view.OnCancelButtonClick += HandleCancelButtonClick;
        }

        private void HandleSetup (string title, string message)
        {
            view.SetTitle(title);
            view.SetMessage(message);
        }

        private void HandleConfirmButtonClick ()
        {
            model.Confirm();
        }

        private void HandleCancelButtonClick ()
        {
            model.Cancel();
        }

        public override void Dispose ()
        {
            base.Dispose();

            view.OnConfirmButtonClick -= HandleConfirmButtonClick;
            view.OnCancelButtonClick -= HandleCancelButtonClick;
        }
    }
}