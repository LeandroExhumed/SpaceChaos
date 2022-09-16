using LeandroExhumed.SpaceChaos.Common;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos
{
    public class MainMenuSceneStarter : MonoBehaviour
    {
        private ILaunchableModel[] meteors;

        [Inject]
        public void Constructor (ILaunchableModel[] meteors)
        {
            this.meteors = meteors;
        }

        private void Awake ()
        {
            for (int i = 0; i < meteors.Length; i++)
            {
                meteors[i].Initialize();
                meteors[i].GetLaunched();
            }
        }
    }
}