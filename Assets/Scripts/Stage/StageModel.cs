using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Player;
using System;
using System.Collections;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageModel : IStageModel
    {
        public event Action OnEnd;
        public event Action OnGameOver;

        private const float RESPAWN_DELAY = 4f;

        private int enemies;

        private float timer = 0;
        private float secondsToCheckProbability = 10;

        private readonly Pause pause;

        private readonly IAsteroindSpawningModel asteroindSpawning;
        private readonly IDamageableModel ship;
        private readonly ILifeModel life;
        private readonly IScoreModel score;

        private readonly IInput input;

        private readonly MonoBehaviour monoBehaviour;

        public StageModel (
            Pause pause,
            IAsteroindSpawningModel asteroindSpawning,
            IDamageableModel ship,
            ILifeModel life,
            IScoreModel score,
            IInput input,
            MonoBehaviour monoBehaviour)
        {
            this.pause = pause;
            this.asteroindSpawning = asteroindSpawning;
            this.ship = ship;
            this.life = life;
            this.score = score;
            this.input = input;
            this.monoBehaviour = monoBehaviour;
        }

        public void Initialize ()
        {
            ship.OnDeath += HandleShipDeath;
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
            if (timer >= secondsToCheckProbability)
            {
                float probability = UnityEngine.Random.value;
                if (probability >= 0.5f)
                {
                    //ufoSpawner.createUFO();
                    //enemies++;
                    Debug.Log("UFO spawned");
                }

                timer = 0;
            }

            timer += Time.deltaTime;
        }

        public void End ()
        {
            input.OnPausePerformed -= HandlePausePerformed;
            OnEnd?.Invoke();
        }

        private void RegisterMeteor (MeteorFacade meteor)
        {
            meteor.OnDeath += HandleMeteorDestruction;
            meteor.OnNewPiece += HandleNewPiece;
            enemies++;
        }

        public void HandleShipDeath (DeathInfo ship)
        {
            if (life.Life == 0)
            {
                OnGameOver?.Invoke();
            }
            else
            {
                monoBehaviour.StartCoroutine(PlayerRespawningDelayRoutine(ship.Damageable));
            }
        }

        private void HandleNewPiece (MeteorFacade piece)
        {
            RegisterMeteor(piece);
        }

        private void HandleMeteorDestruction (DeathInfo deathInfo)
        {
            enemies--;
            score.AddPoints(deathInfo.XPReward);
            if (enemies == 0)
            {
                End();
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

        private IEnumerator PlayerRespawningDelayRoutine (IDamageableModel ship)
        {
            yield return new WaitForSeconds(RESPAWN_DELAY);
            ship.Resurrect();
        }

        public void Dispose ()
        {
            ship.OnDeath -= HandleShipDeath;
        }
    }
}