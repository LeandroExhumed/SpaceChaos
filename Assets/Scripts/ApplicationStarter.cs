using LeandroExhumed.SpaceChaos.Stage;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos
{
    public class ApplicationStarter : MonoBehaviour
    {
        private IStageModel stage;

        private void Awake ()
        {
            stage.Initialize(4);
        }
    }
}