namespace LeandroExhumed.SpaceChaos.Common.Damage
{
    public struct DeathInfo
    {
        public string InstanceID { get; private set; }
        public int XPReward { get; private set; }

        public DeathInfo (string instanceID, int xPReward = 0)
        {
            InstanceID = instanceID;
            XPReward = xPReward;
        }
    }
}