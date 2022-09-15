using LeandroExhumed.SpaceChaos.Common;
using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public interface IRouteMovement
    {
        event Action<string> OnLeaving;

        void Initialize (Vector3 position);
        void Tick ();
    }
}