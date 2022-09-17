using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    [CreateAssetMenu(fileName = "Meteor", menuName = "Enemies/Meteor")]
    public class MeteorData : EnemyData
    {
        public float Speed => speed;
        public int PieceAmount => pieceAmount;

        [SerializeField]
        private float speed = 50f;
        [SerializeField]
        private int pieceAmount = 2;
    }
}