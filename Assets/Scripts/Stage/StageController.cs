using LeandroExhumed.SpaceChaos.Common.Damage;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageController : IController
    {
        private readonly IStageModel model;
        
        private readonly IDamageableModel ship;

        public StageController (IStageModel model, IDamageableModel ship)
        {
            this.model = model;
            this.ship = ship;
        }

        public void Setup ()
        {
            ship.OnDeath += HandleShipDeath;
        }

        private void HandleShipDeath (IDamageableModel ship)
        {
            model.HandleShipDeath(ship);
        }
        public void Dispose ()
        {
            ship.OnDeath -= HandleShipDeath;
        }
    }
}