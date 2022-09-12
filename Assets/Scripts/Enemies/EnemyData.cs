using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies
{
    public class EnemyData : ScriptableObject
    {
        public int RewardPoints => rewardPoints;

        [SerializeField]
        private int rewardPoints = 80;
    }
}