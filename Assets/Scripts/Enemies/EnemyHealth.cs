using LeandroExhumed.SpaceChaos.Common.Damage;

namespace LeandroExhumed.SpaceChaos.Enemies
{
    public class EnemyHealth : Health
    {
        private readonly int xpReward;

        public EnemyHealth (int xpReward)
        {
            this.xpReward = xpReward;
        }

        protected override DeathInfo GetDeathInfo ()
        {
            return new DeathInfo(this, xpReward);
        }
    }
}