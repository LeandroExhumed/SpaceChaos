using Zenject;

namespace LeandroExhumed.SpaceChaos.UI.GameOverScreen
{
    public class GameOverMenuContainer : MonoInstaller
    {
        public override void InstallBindings ()
        {
            Container.Bind<IGameOverMenuModel>().To<GameOverMenuModel>().AsSingle();
            Container.Bind<IController>().To<GameOverMenuController>().AsSingle();
            Container.BindInstance(GetComponent<GameOverMenuView>()).AsSingle();
        }
    }
}