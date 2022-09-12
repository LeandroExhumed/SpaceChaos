using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class OffscreenDetectorModel : IOffscreenDetectorModel
    {
        public event Action<Edge> OnOffscreen;

        private readonly Transform transform;

        private readonly Camera camera;

        public OffscreenDetectorModel (Transform transform, Camera camera)
        {
            this.transform = transform;
            this.camera = camera;
        }

        public void Tick ()
        {
            Vector3 screenPos = camera.WorldToScreenPoint(transform.position);
            Edge edge = Edge.None;
            if (screenPos.x < 0)
            {
                edge = Edge.Left;
            }
            else if (screenPos.x > Screen.width)
            {
                edge = Edge.Right;
            }
            if (screenPos.y < 0)
            {
                edge = Edge.Bottom;
            }
            else if (screenPos.y > Screen.height)
            {
                edge = Edge.Top;
            }

            if (edge != Edge.None)
            {
                OnOffscreen?.Invoke(edge);
            }
        }
    }

    public enum Edge
    {
        None,
        Left,
        Right,
        Bottom,
        Top
    }
}