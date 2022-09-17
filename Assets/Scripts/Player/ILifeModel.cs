using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public interface ILifeModel
    {
        int Life { get; set; }

        event Action<int> OnLifeChanged;

        void Initialize (int startLife);
        void AddLife ();
        void LoseLife ();
    }
}