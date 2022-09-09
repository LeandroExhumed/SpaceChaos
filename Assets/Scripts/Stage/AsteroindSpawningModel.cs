using LeandroExhumed.SpaceChaos.Constants;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class AsteroindSpawningModel : IAsteroindSpawningModel
    {
        private const float SAFE_SPAWN_RADIUS = 4F;

        private readonly MeteorFacade.Factory meteorFactory;

        public AsteroindSpawningModel (MeteorFacade.Factory meteorFactory)
        {
            this.meteorFactory = meteorFactory;
        }

        public MeteorFacade Spawn ()
        {
            MeteorFacade meteor = meteorFactory.Create();
            meteor.Initialize(GetRandomPosition(), Quaternion.Euler(Random.value * 360, 90f, 0f));
            meteor.GetLaunched();

            return meteor;
        }

        private Vector3 GetRandomPosition ()
        {
            Vector3 randomPosition;

            do
            {
                randomPosition = new Vector3(ScreenPositions.RandomXPosition, ScreenPositions.RandomYPosition, 0f);
            } while (Physics.OverlapSphere(randomPosition, SAFE_SPAWN_RADIUS).Length > 0);

            return randomPosition;
        }
    }
}