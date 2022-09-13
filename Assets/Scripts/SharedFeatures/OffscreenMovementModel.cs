using LeandroExhumed.SpaceChaos.Constants;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class OffscreenMovementModel : IOffscreenMovementModel
    {
        private float OffSet => transform.localScale.x / 2f;

        private readonly IOffscreenDetectorModel offscreenDetector;
        private readonly Transform transform;
        private readonly Rigidbody rigidbody;

        public OffscreenMovementModel (
            IOffscreenDetectorModel offscreenDetector,
            Transform transform,
            Rigidbody rigidbody)
        {
            this.offscreenDetector = offscreenDetector;
            this.transform = transform;
            this.rigidbody = rigidbody;
        }

        public void Initialize ()
        {
            offscreenDetector.OnOffscreen += HandleOffscreen;
        }

        private void HandleOffscreen (Edge edge)
        {
            Vector3 newPosition = rigidbody.position;
            switch(edge)
            {
                case Edge.Left:
                    newPosition.x = ScreenPositions.RightLimit - OffSet;
                    break;
                case Edge.Right:
                    newPosition.x = ScreenPositions.LeftLimit + OffSet;
                    break;
                case Edge.Bottom:
                    newPosition.y = ScreenPositions.TopLimit - OffSet;
                    break;
                case Edge.Top:
                    newPosition.y = ScreenPositions.BottomLimit + OffSet;
                    break;
            }

            rigidbody.MovePosition(newPosition);
        }
    }
}