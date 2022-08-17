using System;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public interface ISplittableModel
    {
        event Action OnNewPiece;

        void Split ();
    }
}