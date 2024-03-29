using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionFacade : MonoBehaviour, ISessionModel
    {
        public event Action OnStageCompleted
        {
            add => model.OnStageCompleted += value;
            remove => model.OnStageCompleted -= value;
        }
        public event Action OnNewStageStarted
        {
            add => model.OnNewStageStarted += value;
            remove => model.OnNewStageStarted -= value;
        }
        public event Action OnGameOver
        {
            add => model.OnGameOver += value;
            remove => model.OnGameOver -= value;
        }

        public int CurrentStage => model.CurrentStage;

        private ISessionModel model;
        private IController controller;

        [Inject]
        public void Constructor (ISessionModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;
        }

        public void Initialize ()
        {
            controller.Setup();
            model.Initialize();
        }

        public void Begin () => model.Begin();

        public void Tick () => model.Tick();

        public void Dispose ()
        {
            model.Dispose();
            controller.Dispose();
        }

        private void OnDestroy ()
        {
            Dispose();
        }
    }
}