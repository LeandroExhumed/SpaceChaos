using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
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

        private const float TIME_TO_NEXT_STAGE = 3f;
        private const float RESPAWN_DELAY = 4f;

        private int asteroidsPerStage;
        private int enemies;

        private float timer = 0;
        private float secondsToCheckProbability = 10;

        private readonly IAsteroindSpawningModel asteroindSpawning;
        private readonly ILifeModel life;

        private readonly MonoBehaviour monoBehaviour;

        public StageModel (IAsteroindSpawningModel asteroindSpawning, ILifeModel life, MonoBehaviour monoBehaviour)
        {
            this.asteroindSpawning = asteroindSpawning;
            this.life = life;
            this.monoBehaviour = monoBehaviour;
        }

        public void Initialize (int startAsteroidsAmount)
        {
            asteroidsPerStage = startAsteroidsAmount;
        }

        public void Begin ()
        {
            for (int i = 0; i < asteroidsPerStage; i++)
            {
                MeteorFacade meteor = asteroindSpawning.Spawn();
                RegisterMeteor(meteor);
            }
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

        public void HandleShipDeath (IDamageableModel ship)
        {
            if (life.Life == 0)
            {
                OnGameOver?.Invoke();
            }
            else
            {
                monoBehaviour.StartCoroutine(PlayerRespawningDelayRoutine(ship));
            }
        }

        public void End ()
        {
            monoBehaviour.StartCoroutine(NextStagePassageDelayRoutine());
            OnEnd?.Invoke();
        }

        private void RegisterMeteor (MeteorFacade meteor)
        {
            meteor.OnDeath += HandleMeteorDestruction;
            meteor.OnNewPiece += HandleNewPiece;
            enemies++;
        }

        private void HandleNewPiece (MeteorFacade piece)
        {
            RegisterMeteor(piece);
        }

        private void HandleMeteorDestruction (IDamageableModel obj)
        {
            enemies--;
            if (enemies == 0)
            {
                End();
            }
        }

        private IEnumerator PlayerRespawningDelayRoutine (IDamageableModel ship)
        {
            yield return new WaitForSeconds(RESPAWN_DELAY);
            ship.Resurrect();
        }

        private IEnumerator NextStagePassageDelayRoutine ()
        {
            yield return new WaitForSeconds(TIME_TO_NEXT_STAGE);
            Begin();
        }
    }
}