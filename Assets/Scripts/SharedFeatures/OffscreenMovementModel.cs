using LeandroExhumed.SpaceChaos.Constants;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class OffscreenMovementModel : IOffscreenMovementModel
    {
        private float OffSet => transform.localScale.x / 2f;

        private readonly Transform transform;

        private readonly Camera camera;

        public OffscreenMovementModel (Transform transform, Rigidbody rigidbody, Camera camera)
        {
            this.transform = transform;
            this.camera = camera;
        }

        public void Overflow ()
        {
            Vector3 screenPos = camera.WorldToScreenPoint(transform.position);
            Vector3 newPosition = transform.position;
            if (screenPos.x < 0)
            {
                newPosition.x = ScreenPositions.RightLimit + OffSet;
            }
            else if (screenPos.x > Screen.width)
            {
                newPosition.x = ScreenPositions.LeftLimit - OffSet;
            }
            if (screenPos.y < 0)
            {
                newPosition.y = ScreenPositions.TopLimit + OffSet;
            }
            else if (screenPos.y > Screen.height)
            {
                newPosition.y = ScreenPositions.BottomLimit - OffSet;
            }

            transform.position = newPosition;
        }
    }
}