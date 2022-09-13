using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using LeandroExhumed.SpaceChaos.Enemies.UFO;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Player;
using LeandroExhumed.SpaceChaos.Session;
using LeandroExhumed.SpaceChaos.UI.GameOverScreen;
using System;
using System.Collections;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageModel : IStageModel
    {
        public event Action OnCompleted;

        private const float RESPAWN_DELAY = 3f;

        private int enemies;
        private bool onAdvancedScore = false;
        private bool hasGameOver = false;

        private float timer = 0;

        private readonly SessionData sessionData;

        private readonly Pause pause;

        private readonly IAsteroindSpawningModel asteroindSpawning;
        private readonly UFOFactory ufoFactory;

        private readonly IDamageableModel ship;
        private readonly ILifeModel life;
        private readonly IScoreModel score;

        private readonly IGameOverMenuModel gameOverMenu;

        private readonly IInput input;

        private readonly MonoBehaviour monoBehaviour;

        public StageModel (
            SessionData sessionData,
            Pause pause,
            IAsteroindSpawningModel asteroindSpawning,
            UFOFactory ufoFactory,
            IDamageableModel ship,
            ILifeModel life,
            IScoreModel score,
            IGameOverMenuModel gameOverMenu,
            IInput input,
            MonoBehaviour monoBehaviour)
        {
            this.sessionData = sessionData;
            this.pause = pause;
            this.asteroindSpawning = asteroindSpawning;
            this.ufoFactory = ufoFactory;
            this.ship = ship;
            this.life = life;
            this.score = score;
            this.gameOverMenu = gameOverMenu;
            this.input = input;
            this.monoBehaviour = monoBehaviour;
        }

        public void Initialize ()
        {
            ship.OnDeath += HandleShipDeath;
            score.OnRewardWon += HandleRewardWon;
            score.OnAdvancedScoreReached += HandleAdvancedScoreReached;
        }

        public void Begin (int startAsteroidsAmount)
        {
            for (int i = 0; i < startAsteroidsAmount; i++)
            {
                MeteorFacade meteor = asteroindSpawning.Spawn();
                RegisterMeteor(meteor);
            }

            input.OnPausePerformed += HandlePausePerformed;
        }

        public void Tick ()
        {
            if (timer >= sessionData.UFOSpawningInterval)
            {
                float probability = UnityEngine.Random.value;
                if (probability >= 0.5f)
                {
                    CreateUFO();
                }

                timer = 0;
            }

            timer += Time.deltaTime;
        }

        private void End (bool endedByGameOver)
        {
            input.OnPausePerformed -= HandlePausePerformed;
            if (endedByGameOver)
            {
                hasGameOver = true;
                input.SetActive(true);
                gameOverMenu.Setup(score.Score);
            }
            else
            {
                OnCompleted?.Invoke();
            }
        }

        private void RegisterMeteor (MeteorFacade meteor)
        {
            RegisterEnemy(meteor);
            meteor.OnNewPiece += HandleNewPiece;
        }
        
        private void RegisterUFO (UFOFacade ufo)
        {
            RegisterEnemy(ufo);
            ufo.OnLeaving += HandleUFOLeaving;
        }

        private void RegisterEnemy (IDamageableModel enemy)
        {
            enemy.OnDeath += HandleEnemyDeath;
            enemies++;
        }

        private void CreateUFO ()
        {
            UFOFacade ufo;
            if (onAdvancedScore)
            {
                ufo = ufoFactory.Spawn(UFOType.Small);
            }
            else
            {
                float probability = UnityEngine.Random.value;
                if (probability > 0.5f)
                {
                    ufo = ufoFactory.Spawn(UFOType.Big);
                }
                else
                {
                    ufo = ufoFactory.Spawn(UFOType.Small);
                }
            }

            RegisterUFO(ufo);
        }

        public void HandleShipDeath (DeathInfo ship)
        {
            life.LoseLife();

            Action onDelayOver;
            if (life.Life == 0)
            {
                onDelayOver = () => End(true);
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

        private void HandleAdvancedScoreReached ()
        {
            onAdvancedScore = true;
        }

        private void HandleNewPiece (MeteorFacade piece)
        {
            RegisterMeteor(piece);
        }

        private void HandleUFOLeaving ()
        {
            RemoveEnemy();
        }

        private void HandleEnemyDeath (DeathInfo deathInfo)
        {            
            score.AddPoints(deathInfo.XPReward);
            RemoveEnemy();
        }

        private void RemoveEnemy ()
        {
            if (hasGameOver)
            {
                return;
            }

            enemies--;
            if (enemies == 0)
            {
                End(false);
            }
        }

        private void HandlePausePerformed ()
        {
            if (Time.timeScale == 0)
            {
                return;
            }

            pause.Execute();
        }

        private IEnumerator ShipDestructionDelayRoutine (Action onDelayOver)
        {
            yield return new WaitForSeconds(RESPAWN_DELAY);
            onDelayOver.Invoke();
        }

        public void Dispose ()
        {
            ship.OnDeath -= HandleShipDeath;
            score.OnRewardWon -= HandleRewardWon;
            score.OnAdvancedScoreReached -= HandleAdvancedScoreReached;
        }
    }
}