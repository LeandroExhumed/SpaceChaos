using LeandroExhumed.SpaceChaos.Session;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class GameplayStarter : MonoBehaviour
    {
        private ISessionModel session;

        [Inject]
        public void Constructor (ISessionModel session)
        {
            this.session = session;
        }

        private void Awake ()
        {
            session.Initialize();
            session.Begin();
        }
    }
}