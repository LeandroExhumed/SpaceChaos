using LeandroExhumed.SpaceChaos.Constants;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class UFOFactory : EnemyFactory
    {
        private readonly UFOFacade.Factory[] meteorFactory;

        public UFOFactory (UFOFacade.Factory[] meteorFactory)
        {
            this.meteorFactory = meteorFactory;
        }

        public UFOFacade Spawn (UFOType type)
        {
            UFOFacade meteor = meteorFactory[(int)type].Create();
            meteor.Initialize(TryGetSafePosition());

            return meteor;
        }

        protected override Vector3 GetRandomPosition ()
        {
            return new Vector3(ScreenPositions.LeftLimit, ScreenPositions.RandomYPosition, 0f);
        }
    }

    public enum UFOType
    {
        Small,
        Big
    }
}