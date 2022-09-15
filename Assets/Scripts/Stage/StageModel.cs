using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Enemies;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using LeandroExhumed.SpaceChaos.Enemies.UFO;
using LeandroExhumed.SpaceChaos.Player;
using LeandroExhumed.SpaceChaos.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageModel : IStageModel
    {
        public event Action OnCompleted;

        private readonly List<EnemyFacade> enemies = new();
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

        private void RegisterEnemy (EnemyFacade enemy)
        {
            enemy.OnDeath += HandleEnemyDeath;
            enemies.Add(enemy);
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

        private void HandleUFOLeaving (string instanceID)
        {
            RemoveEnemy(instanceID);
        }

        private void HandleEnemyDeath (DeathInfo deathInfo)
        {            
            score.AddPoints(deathInfo.XPReward);
            RemoveEnemy(deathInfo.InstanceID);
        }

        private void RemoveEnemy (string instanceID)
        {
            EnemyFacade enemy = enemies.First(x => x.InstanceID == instanceID);
            RemoveEnemyListeners(enemy);

            enemies.Remove(enemy);
            if (enemies.Count == 0)
            {
                OnCompleted?.Invoke();
            }
        }

        private void RemoveEnemyListeners (EnemyFacade enemy)
        {
            enemy.OnDeath -= HandleEnemyDeath;
            if (enemy is UFOFacade ufo)
            {
                ufo.OnLeaving -= HandleUFOLeaving;
            }
        }

        public void Dispose ()
        {
            score.OnAdvancedScoreReached -= HandleAdvancedScoreReached;
            for (int i = 0; i < enemies.Count; i++)
            {
                RemoveEnemyListeners(enemies[i]);
            }
        }
    }
}