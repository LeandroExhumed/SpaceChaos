using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Constants;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class RouteMovement : IRouteMovement
    {
        public event Action OnLeaving;

        private Vector3 randomPosition;

        private readonly UFOData data;
        private readonly IOffscreenDetectorModel offscreenDetector;
        private readonly Transform transform;

        public RouteMovement (UFOData data, IOffscreenDetectorModel offscreenDetector, Transform transform)
        {
            this.data = data;
            this.offscreenDetector = offscreenDetector;
            this.transform = transform;
        }

        public void Initialize (Vector3 position)
        {
            transform.position = position;

            offscreenDetector.OnOffscreen += OnOffscreen;

            DefineNewDestination();
        }

        public void Tick ()
        {
            float step = data.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, randomPosition, step);

            if (Vector3.Distance(transform.position, randomPosition) <= 0)
            {
                DefineNewDestination();
            }
        }

        private void OnOffscreen (Edge edge)
        {
            OnLeaving?.Invoke();
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