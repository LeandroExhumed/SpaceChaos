using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using LeandroExhumed.SpaceChaos.Player;
using LeandroExhumed.SpaceChaos.Stage;
using LeandroExhumed.SpaceChaos.UI.GameOverScreen;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionContainer : MonoInstaller
    {
        [SerializeField]
        private ShipFacade player;

        [SerializeField]
        private SessionView view;
        [SerializeField]
        private GameOverMenuFacade gameOverMenu;
        [SerializeField]
        private PlayerUIView playerUIVIew;

        [SerializeField]
        private MeteorFacade meteorPrefab;

        public override void InstallBindings ()
        {
            ResolveMVC();
            Container.BindInstance(GetComponent<MonoBehaviour>()).AsSingle();

            Container.Bind<IDamageableModel>().FromInstance(player).AsSingle();
            Container.Bind<ILifeModel>().To<LifeModel>().AsSingle();
            Container.Bind<IScoreModel>().To<ScoreModel>().AsSingle();

            Container.Bind<IGameOverMenuModel>().FromInstance(gameOverMenu).AsSingle();
            Container.BindInstance(playerUIVIew).AsSingle();

            ResolveStage();
        }

        private void ResolveMVC ()
        {
            Container.Bind<ISessionModel>().To<SessionModel>().AsSingle();
            Container.Bind<IController>().To<SessionController>().AsSingle();
            Container.BindInstance(view).AsSingle();
        }

        private void ResolveStage ()
        {
            Container.Bind<IStageModel>().To<StageModel>().AsSingle();
            Container.BindFactory<MeteorFacade, MeteorFacade.Factory>()
                .FromComponentInNewPrefab(meteorPrefab);
            Container.Bind<IAsteroindSpawningModel>().To<AsteroindSpawningModel>().AsSingle();
        }
    }
}