using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Pooling;
using LeandroExhumed.UI.Navigation;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class ProjectContainer : MonoInstaller
    {
        [SerializeField]
        private NavigationFlowFacade navigationFlow;

        public override void InstallBindings ()
        {
            Container.Bind<Pool>().AsSingle();
            Container.Bind<AudioProvider>().AsSingle();
            Container.Bind<PlayerActions>().AsSingle();
            Container.Bind<IInput>().To<PlayerInput>().AsSingle();
            Container.Bind<INavigationFlowModel>().FromInstance(navigationFlow).AsSingle();
        }
    } 
}