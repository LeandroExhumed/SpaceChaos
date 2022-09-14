using LeandroExhumed.SpaceChaos.Input;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionController : IController
    {
        private readonly ISessionModel model;
        private readonly Pause pause;

        private readonly SessionView view;
        private readonly IInput input;

        public SessionController (ISessionModel model, Pause pause, SessionView view, IInput input)
        {
            this.model = model;
            this.pause = pause;
            this.view = view;
            this.input = input;
        }

        public void Setup ()
        {
            model.OnStageCompleted += HandleEnd;
            model.OnNewStageStarted += HandleNewStageStarted;
            model.OnGameOver += HandleGameOver;
            view.OnUpdate += HandleViewUpdate;
        }

        private void HandleEnd ()
        {
            view.SetSuccessMessageActive(true);
        }

        private void HandleNewStageStarted ()
        {
            input.OnPausePerformed += HandlePausePerformed;
            view.SetSuccessMessageActive(false);
        }

        private void HandleGameOver ()
        {
            input.OnPausePerformed -= HandlePausePerformed;
            input.SetActive(true);
        }

        private void HandleViewUpdate ()
        {
            model.Tick();
        }

        private void HandlePausePerformed ()
        {
            if (Time.timeScale == 0)
            {
                return;
            }

            pause.Execute();
        }

        public void Dispose ()
        {
            model.OnStageCompleted -= HandleEnd;
            model.OnNewStageStarted -= HandleNewStageStarted;
            view.OnUpdate -= HandleViewUpdate;
            input.OnPausePerformed -= HandlePausePerformed;
        }
    }
}