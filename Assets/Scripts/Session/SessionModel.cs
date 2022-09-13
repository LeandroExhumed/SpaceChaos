using LeandroExhumed.SpaceChaos.Stage;
using System;
using System.Collections;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionModel : ISessionModel
    {
        public event Action OnStageCompleted;
        public event Action OnNewStageStarted;

        public int CurrentStage { get; private set; } = 1;
        private IStageModel stage;

        private const float TIME_TO_NEXT_STAGE = 3f;

        private readonly SessionData data;
        private readonly IStageModel.Factory stageFactory;
        private readonly MonoBehaviour monoBehaviour;

        public SessionModel (SessionData data, IStageModel.Factory stageFactory, MonoBehaviour monoBehaviour)
        {
            this.data = data;
            this.stageFactory = stageFactory;
            this.monoBehaviour = monoBehaviour;
        }

        public void Initialize ()
        {
            CreateStage();
        }

        public void Tick ()
        {
            if (stage == null)
            {
                return;
            }

            stage.Tick();
        }

        private void CreateStage ()
        {
            stage = stageFactory.Create();
            stage.OnCompleted += HandleStageCompleted;
            stage.Initialize();
            stage.Begin(data.StartMeteorAmount + (CurrentStage - 1));
        }

        private void HandleStageCompleted ()
        {
            CurrentStage++;
            stage.Dispose();
            stage = null;

            monoBehaviour.StartCoroutine(NextStagePassageDelayRoutine());

            OnStageCompleted?.Invoke();
        }

        private IEnumerator NextStagePassageDelayRoutine ()
        {
            yield return new WaitForSeconds(TIME_TO_NEXT_STAGE);
            CreateStage();

            OnNewStageStarted?.Invoke();
        }

        public void Dispose ()
        {
            stage.OnCompleted -= HandleStageCompleted;
        }
    }
}