using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies
{
    public abstract class EnemyFactory
    {
        private const float SAFE_SPAWN_RADIUS = 2F;
        private const int ATTEMPTS_TO_FIND_POSITION = 30;

        protected Vector3 TryGetSafePosition ()
        {
            Vector3 randomPosition;
            int attempts = 0;

            do
            {
                randomPosition = GetRandomPosition();
                attempts++;
            } while (Physics.OverlapSphere(randomPosition, SAFE_SPAWN_RADIUS).Length > 0
            && attempts < ATTEMPTS_TO_FIND_POSITION);


            return randomPosition;
        }

        protected abstract Vector3 GetRandomPosition ();
    }
}