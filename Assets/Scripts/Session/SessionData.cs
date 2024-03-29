﻿using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Session
{
    [CreateAssetMenu(fileName = "Session", menuName = "Session")]
    public class SessionData : ScriptableObject
    {
        public int StartMeteorAmount => startMeteorAmount;
        public float UFOSpawningInterval => ufoSpawningInterval;
        public float UfoSpawningProbability => ufoSpawningProbability;
        public int Lifes => lifes;
        public int StartScoreToReward => startScoreToReward;
        public int AdvancedScore => advancedScore;

        [SerializeField]
        private int startMeteorAmount = 4;
        [SerializeField]
        [Range(0, 1)]
        private float ufoSpawningProbability = 0.5f;
        [SerializeField]
        private float ufoSpawningInterval = 10;
        [SerializeField]
        private int lifes = 3;
        [SerializeField]
        private int startScoreToReward = 10000;
        [SerializeField]
        private int advancedScore = 40000;
    }
}