using LeandroExhumed.SpaceChaos.Constants;
using LeandroExhumed.SpaceChaos.Enemies;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class MeteorFactory : EnemyFactory
    {
        private readonly MeteorFacade.Factory meteorFactory;

        public MeteorFactory (MeteorFacade.Factory meteorFactory)
        {
            this.meteorFactory = meteorFactory;
        }

        public MeteorFacade Spawn ()
        {
            MeteorFacade meteor = meteorFactory.Create();
            meteor.Initialize(TryGetSafePosition(), Quaternion.Euler(Random.value * 360, 90f, 0f));
            meteor.GetLaunched();

            return meteor;
        }

        protected override Vector3 GetRandomPosition ()
        {
            return new Vector3(ScreenPositions.RandomXPosition, ScreenPositions.RandomYPosition, 0f);
        }
    }
}