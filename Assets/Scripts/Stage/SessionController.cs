namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionController : IController
    {
        private readonly ISessionModel model;
        private readonly SessionView view;
        

        public SessionController (ISessionModel model, SessionView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Setup ()
        {
            model.OnStageCompleted += HandleEnd;
            model.OnNewStageStarted += HandleNewStageStarted;
            view.OnUpdate += HandleViewUpdate;
        }

        private void HandleViewUpdate ()
        {
            model.Tick();
        }

        private void HandleEnd ()
        {
            view.SetSuccessMessageActive(true);
        }

        private void HandleNewStageStarted ()
        {
            view.SetSuccessMessageActive(false);
        }

        public void Dispose ()
        {
            model.OnStageCompleted -= HandleEnd;
            model.OnNewStageStarted -= HandleNewStageStarted;
            view.OnUpdate -= HandleViewUpdate;
        }
    }
}