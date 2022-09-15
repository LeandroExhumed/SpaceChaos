using LeandroExhumed.SpaceChaos.Common.Damage;

namespace LeandroExhumed.SpaceChaos.Enemies
{
    public class EnemyHealth : Health
    {
        private readonly int xpReward;

        public EnemyHealth (string instanceID, int xpReward) : base (instanceID)
        {
            this.xpReward = xpReward;
        }

        protected override DeathInfo GetDeathInfo ()
        {
            return new DeathInfo(instanceID, xpReward);
        }
    }
}