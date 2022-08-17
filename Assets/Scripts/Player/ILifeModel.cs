using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public interface ILifeModel
    {
        int Life { get; set; }

        event Action<int> OnLifeChanged;

        void AddLife ();
        void Initialize (int startLife);
        void LoseLife ();
    }
}