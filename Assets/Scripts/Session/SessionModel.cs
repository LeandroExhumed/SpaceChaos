using LeandroExhumed.SpaceChaos.Stage;
using System;
using System.Collections;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionModel : ISessionModel
    {
        public event Action OnStageEnded;
        public event Action OnNewStageStarted;

        private const float TIME_TO_NEXT_STAGE = 3f;
        private int currentStage = 1;

        private readonly IStageModel stage;

        private readonly MonoBehaviour monoBehaviour;

        public SessionModel (IStageModel stage, MonoBehaviour monoBehaviour)
        {
            this.stage = stage;
            this.monoBehaviour = monoBehaviour;
        }

        public void Initialize ()
        {
            stage.OnEnd += HandleStageEnd;
            stage.Initialize();
            stage.Begin(4);
        }

        private void HandleStageEnd ()
        {
            currentStage++;
            monoBehaviour.StartCoroutine(NextStagePassageDelayRoutine());

            OnStageEnded?.Invoke();
        }

        private IEnumerator NextStagePassageDelayRoutine ()
        {
            yield return new WaitForSeconds(TIME_TO_NEXT_STAGE);
            stage.Begin(4 + (currentStage - 1));

            OnNewStageStarted?.Invoke();
        }

        public void Dispose ()
        {
            stage.OnEnd -= HandleStageEnd;
        }
    }
}