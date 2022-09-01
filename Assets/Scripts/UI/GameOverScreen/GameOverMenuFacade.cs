using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.UI.GameOverScreen
{
    public class GameOverMenuFacade : MonoBehaviour, IGameOverMenuModel
    {
        public event Action<int, int> OnSetup
        {
            add => model.OnSetup += value;
            remove => model.OnSetup -= value;
        }

        private IGameOverMenuModel model;
        private IController controller;

        [Inject]
        public void Constructor (IGameOverMenuModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;

            controller.Setup();
        }

        public void Setup (int points) => model.Setup(points);

        public void QuitToMainMenu () => model.QuitToMainMenu();

        private void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}