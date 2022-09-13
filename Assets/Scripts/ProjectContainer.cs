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

        [SerializeField]
        private SoundCatalog catalog;
        [SerializeField]
        private AudioSource musicAudioSource;
        [SerializeField]
        private AudioSource sfxAudioSource;

        public override void InstallBindings ()
        {
            Container.Bind<Pool>().AsSingle();
            Container.Bind<INavigationFlowModel>().FromInstance(navigationFlow).AsSingle();
            ResolveInput();
            ResolveAudio();
        }

        private void ResolveInput ()
        {
            Container.Bind<PlayerActions>().AsSingle();
            Container.Bind<IInput>().To<PlayerInput>().AsSingle();
        }

        private void ResolveAudio ()
        {
            Container.BindInstance(catalog).AsCached();
            Container.BindInstance(musicAudioSource).AsCached();
            Container.BindInstance(sfxAudioSource).WithId("SFX").AsCached();
            Container.BindInstance(transform).WhenInjectedInto<AudioProvider>();
            Container.Bind<AudioProvider>().AsSingle();
        }
    } 
}