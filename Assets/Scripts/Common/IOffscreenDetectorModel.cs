using System;

namespace LeandroExhumed.SpaceChaos.Common
{
    public interface IOffscreenDetectorModel
    {
        event Action<Edge> OnOffscreen;

        void Tick ();
    }
}