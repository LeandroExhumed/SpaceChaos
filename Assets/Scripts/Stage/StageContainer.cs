using LeandroExhumed.SpaceChaos.Common.Damage;
using LeandroExhumed.SpaceChaos.Player;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageContainer : MonoInstaller
    {
        [SerializeField]
        private ShipFacade player;

        [SerializeField]
        private PlayerUIView playerUIVIew;

        public override void InstallBindings ()
        {
            ResolveMVC();
            Container.BindInstance(GetComponent<MonoBehaviour>()).AsSingle();

            Container.Bind<IDamageableModel>().FromInstance(player).AsSingle();
            Container.Bind<ILifeModel>().To<LifeModel>().AsSingle();
            Container.Bind<IScoreModel>().To<ScoreModel>().AsSingle();

            Container.BindInstance(playerUIVIew).AsSingle();
        }

        private void ResolveMVC ()
        {
            Container.Bind<IStageModel>().To<StageModel>().AsSingle();
            Container.Bind<IController>().To<StageController>().AsSingle();
        }
    }
}