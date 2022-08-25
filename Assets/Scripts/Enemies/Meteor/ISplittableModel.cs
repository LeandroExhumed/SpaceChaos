using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public interface ISplittableModel
    {
        event Action OnNewPiece;

        void Split ();
        void Decrease (int timesBroken, Vector3 scale);
    }
}