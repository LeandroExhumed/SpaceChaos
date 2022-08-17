using LeandroExhumed.SpaceChaos.Common.Damage;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageFacade : MonoBehaviour, IStageModel
    {
        public event Action OnEnd
        {
            add => model.OnEnd += value;
            remove => model.OnEnd -= value;
        }

        public event Action OnGameOver
        {
            add => model.OnGameOver += value;
            remove => model.OnGameOver -= value;
        }

        private IStageModel model;
        private IController controller;

        public void Constructor (IStageModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;
        }

        public void Initialize (int startAsteroidsAmount)
        {
            controller.Setup();
            model.Initialize(startAsteroidsAmount);
        }

        public void Begin () => model.Begin();

        public void Tick () => model.Tick();

        public void HandleShipDeath (IDamageableModel ship) => model.HandleShipDeath(ship);

        public void End () => model.End();

        private void OnDestroy ()
        {
            controller.Dispose();
        }
    }
}