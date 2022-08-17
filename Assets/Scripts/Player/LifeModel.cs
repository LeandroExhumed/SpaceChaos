using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class LifeModel : ILifeModel
    {
        public event Action<int> OnLifeChanged;

        public int Life
        {
            get => life;
            set
            {
                life = value;
                OnLifeChanged?.Invoke(value);
            }
        }

        private const int MAX_LIFE = 99990;

        private int life;

        public void Initialize (int startLife)
        {
            Life = startLife;
        }

        public void AddLife ()
        {
            if (Life == MAX_LIFE)
            {
                return;
            }

            Life++;
        }

        public void LoseLife ()
        {
            Life--;
        }
    }
}