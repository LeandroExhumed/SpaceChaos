using LeandroExhumed.SpaceChaos.Constants;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOFactory
    {
        private const float SAFE_SPAWN_RADIUS = 2F;

        private readonly UFOFacade.Factory[] meteorFactory;

        public UFOFactory (UFOFacade.Factory[] meteorFactory)
        {
            this.meteorFactory = meteorFactory;
        }

        public UFOFacade Spawn (UFOType type)
        {
            UFOFacade meteor = meteorFactory[(int)type].Create();
            meteor.Initialize(GetRandomPosition());

            return meteor;
        }

        private Vector3 GetRandomPosition ()
        {
            Vector3 randomPosition;

            do
            {
                randomPosition = new Vector3(ScreenPositions.LeftLimit, ScreenPositions.RandomYPosition, 0f);
            } while (Physics.OverlapSphere(randomPosition, SAFE_SPAWN_RADIUS).Length > 0);


            return randomPosition;
        }
    }

    public enum UFOType
    {
        Small,
        Big
    }
}