using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using LeandroExhumed.SpaceChaos.Enemies.UFO;
using LeandroExhumed.SpaceChaos.Player;
using LeandroExhumed.SpaceChaos.Session;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageModel : IStageModel
    {
        public event Action OnCompleted;

        private int enemies;
        private bool onAdvancedScore = false;        

        private float timer = 0;

        private readonly SessionData sessionData;

        private readonly MeteorFactory asteroindSpawning;
        private readonly UFOFactory ufoFactory;

        private readonly IScoreModel score;

        public StageModel (
            SessionData sessionData,
            MeteorFactory asteroindSpawning,
            UFOFactory ufoFactory,
            IScoreModel score)
        {
            this.sessionData = sessionData;
            this.asteroindSpawning = asteroindSpawning;
            this.ufoFactory = ufoFactory;
            this.score = score;
        }

        public void Initialize ()
        {
            score.OnAdvancedScoreReached += HandleAdvancedScoreReached;
        }

        public void Begin (int startAsteroidsAmount)
        {
            for (int i = 0; i < startAsteroidsAmount; i++)
            {
                MeteorFacade meteor = asteroindSpawning.Spawn();
                RegisterMeteor(meteor);
            }
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
                if (probability > sessionData.UfoSpawningProbability)
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
            enemies--;
            if (enemies == 0)
            {
                OnCompleted?.Invoke();
            }
        }

        public void Dispose ()
        {
            score.OnAdvancedScoreReached -= HandleAdvancedScoreReached;
        }
    }
}