using LeandroExhumed.SpaceChaos.Audio;
using LeandroExhumed.SpaceChaos.Input;
using LeandroExhumed.SpaceChaos.Pooling;
using LeandroExhumed.SpaceChaos.Session;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class ApplicationContainer : MonoInstaller
    {
        [SerializeField]
        private SessionFacade session;

        public override void InstallBindings ()
        {
            Container.Bind<Pool>().AsSingle();
            Container.Bind<AudioProvider>().AsSingle();
            Container.BindInstance(Camera.main).AsSingle();

            Container.Bind<PlayerActions>().AsSingle();

            Container.Bind<ISessionModel>().FromInstance(session).AsSingle();            

            Container.BindInstance(GetComponent<MonoBehaviour>()).AsSingle();
        }
    }
}