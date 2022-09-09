using LeandroExhumed.SpaceChaos.Constants;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class RouteMovement : IRouteMovement
    {
        public event Action OnRouteOver;

        private float speed = 5;
        private Vector3 randomPosition;

        private readonly Transform transform;

        public RouteMovement (Transform transform)
        {
            this.transform = transform;
        }

        public void Initialize (Vector3 position)
        {
            transform.position = position;

            DefineNewDestination();
        }

        public void Tick ()
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, randomPosition, step);

            if (Vector3.Distance(transform.position, randomPosition) <= 0)
            {
                DefineNewDestination();
            }
        }

        public void EndMovement ()
        {
            OnRouteOver?.Invoke();
        }

        private void DefineNewDestination ()
        {
            float positionInX;
            if (Math.Abs(ScreenPositions.RightLimit - transform.position.x) < 0.5f)
            {
                positionInX = ScreenPositions.RightLimit + 5f;
            }
            else
            {
                positionInX = UnityEngine.Random.Range(transform.position.x, ScreenPositions.RightLimit);
            }

            randomPosition = new Vector3(positionInX, ScreenPositions.RandomYPosition, 0f);
        }
    }
}