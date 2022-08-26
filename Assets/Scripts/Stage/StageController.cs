using LeandroExhumed.SpaceChaos.Common.Damage;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageController : IController
    {
        private readonly IStageModel model;
        private readonly StageView view;
        
        private readonly IDamageableModel ship;

        public StageController (IStageModel model, StageView view, IDamageableModel ship)
        {
            this.model = model;
            this.view = view;
            this.ship = ship;
        }

        public void Setup ()
        {
            model.OnEnd += HandleEnd;
            ship.OnDeath += HandleShipDeath;
        }

        private void HandleEnd ()
        {
            view.SetSuccessMessageActive(true);
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