using LeandroExhumed.SpaceChaos.Stage;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class ApplicationStarter : MonoBehaviour
    {
        private IStageModel stage;

        [Inject]
        public void Constructor (IStageModel stage)
        {
            this.stage = stage;
        }

        private void Awake ()
        {
            stage.Initialize(4);
            stage.Begin();
        }
    }
}