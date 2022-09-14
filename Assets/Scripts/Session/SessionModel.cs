using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Player;
using LeandroExhumed.SpaceChaos.Stage;
using LeandroExhumed.SpaceChaos.UI.GameOverScreen;
using System;
using System.Collections;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionModel : ISessionModel
    {
        public event Action OnNewStageStarted;
        public event Action OnStageCompleted;
        public event Action OnGameOver;

        public int CurrentStage { get; private set; } = 1;
        private IStageModel stage;

        private const float TIME_TO_NEXT_STAGE = 3f;
        private const float RESPAWN_DELAY = 3f;
        private bool hasGameOver = false;

        private readonly SessionData data;
        private readonly IStageModel.Factory stageFactory;
        private readonly IDamageableModel ship;
        private readonly ILifeModel life;
        private readonly IScoreModel score;

        private readonly IGameOverMenuModel gameOverMenu;

        private readonly MonoBehaviour monoBehaviour;

        public SessionModel (
            SessionData data,
            IStageModel.Factory stageFactory,
            IDamageableModel ship,
            ILifeModel life,
            IScoreModel score,
            IGameOverMenuModel gameOverMenu,
            MonoBehaviour monoBehaviour)
        {
            this.data = data;
            this.stageFactory = stageFactory;
            this.ship = ship;
            this.life = life;
            this.score = score;
            this.gameOverMenu = gameOverMenu;
            this.monoBehaviour = monoBehaviour;
        }

        public void Initialize ()
        {
            ship.OnDeath += HandleShipDeath;
            score.OnRewardWon += HandleRewardWon;
        }

        public void Begin ()
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

            OnNewStageStarted?.Invoke();
        }

        private void End ()
        {
            hasGameOver = true;
            gameOverMenu.Setup(score.Score);
            OnGameOver?.Invoke();
        }

        private void HandleShipDeath (DeathInfo ship)
        {
            life.LoseLife();

            Action onDelayOver;
            if (life.Life == 0)
            {
                onDelayOver = () => End();
            }
            else
            {
                onDelayOver = () => ship.Damageable.Resurrect();
            }

            monoBehaviour.StartCoroutine(ShipDestructionDelayRoutine(onDelayOver));
        }

        private void HandleRewardWon ()
        {
            life.AddLife();
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
        }

        private IEnumerator ShipDestructionDelayRoutine (Action onDelayOver)
        {
            yield return new WaitForSeconds(RESPAWN_DELAY);
            onDelayOver.Invoke();
        }

        public void Dispose ()
        {
            stage.OnCompleted -= HandleStageCompleted;
            ship.OnDeath -= HandleShipDeath;
            score.OnRewardWon -= HandleRewardWon;
        }
    }
}