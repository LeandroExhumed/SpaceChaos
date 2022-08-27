using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionFacade : MonoBehaviour, ISessionModel
    {
        public event Action OnStageEnded
        {
            add => model.OnStageEnded += value;
            remove => model.OnStageEnded -= value;
        }
        public event Action OnNewStageStarted
        {
            add => model.OnNewStageStarted += value;
            remove => model.OnNewStageStarted -= value;
        }

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

        private void OnDestroy ()
        {
            Dispose();
        }

        public void Dispose ()
        {
            model.Dispose();
            controller.Dispose();
        }
    }
}