using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public interface IRouteMovement
    {
        event Action OnRouteOver;

        void Initialize (Vector3 position);
        void Tick ();
        void EndMovement ();
    }
}