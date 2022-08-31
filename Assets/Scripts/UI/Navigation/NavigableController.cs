namespace LeandroExhumed.UI.Navigation
{
    public class NavigableController : IController
    {
        protected readonly INavigableModel model;
        protected readonly NavigableView view;

        public NavigableController (INavigableModel model, NavigableView view)
        {
            this.model = model;
            this.view = view;
        }

        public virtual void Setup ()
        {
            model.OnOpened += HandleOpened;
            model.OnClosed += HandleClosed;
            view.OnBackButtonClick += HandleBackButtonClick;
            model.OnContentDisplayStatusChanged += HandleContentDisplayStatusChanged;
        }

        private void HandleOpened ()
        {
            view.Open();
        }

        private void HandleClosed ()
        {
            view.Close();
        }

        private void HandleBackButtonClick ()
        {
            model.Back();
        }

        private void HandleContentDisplayStatusChanged (bool active)
        {
            view.SetContentActive(active);
        }

        public virtual void Dispose ()
        {
            model.OnOpened -= HandleOpened;
            model.OnClosed -= HandleClosed;
            view.OnBackButtonClick -= HandleBackButtonClick;
            model.OnContentDisplayStatusChanged -= HandleContentDisplayStatusChanged;
        }
    }
}