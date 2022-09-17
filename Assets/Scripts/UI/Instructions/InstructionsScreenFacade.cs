using LeandroExhumed.UI.Navigation;
using Zenject;

namespace LeandroExhumed.SpaceChaos.UI.InstructionsScreen
{
    public class InstructionsScreenFacade : NavigableFacade
    {
        [Inject]
        public new void Constructor (INavigableModel model, IController controller)
        {
            base.Constructor(model, controller);
        }
    }
}