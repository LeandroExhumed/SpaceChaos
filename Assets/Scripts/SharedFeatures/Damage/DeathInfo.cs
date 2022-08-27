namespace LeandroExhumed.SpaceChaos.Common.Damage
{
    public struct DeathInfo
    {
        public IDamageableModel Damageable { get; private set; }
        public int XPReward { get; private set; }

        public DeathInfo (IDamageableModel instanceID, int xPReward = 0)
        {
            Damageable = instanceID;
            XPReward = xPReward;
        }
    }
}