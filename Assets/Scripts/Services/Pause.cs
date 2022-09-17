using LeandroExhumed.UI.Navigation;
using System.Collections;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Services
{
    public class Pause
    {
        private bool isPaused = false;

        private readonly INavigationFlowModel navigationFlow;
        private readonly INavigableModel pauseMenu;

        private readonly MonoBehaviour monoBehaviour;

        public Pause (INavigationFlowModel navigationFlow, INavigableModel pauseMenu, MonoBehaviour monoBehaviour)
        {
            this.navigationFlow = navigationFlow;
            this.pauseMenu = pauseMenu;
            this.monoBehaviour = monoBehaviour;
        }

        public void Execute (bool showView = true)
        {
            Debug.Log("Pause");
            if (!isPaused)
            {
                monoBehaviour.StartCoroutine(PauseDelayRoutine(showView));

            }
            else
            {
                monoBehaviour.StartCoroutine(UnpauseDelayRoutine(showView));
            }

            isPaused = !isPaused;
        }

        private IEnumerator PauseDelayRoutine (bool showView)
        {
            yield return null;
            Time.timeScale = 0;
            navigationFlow.OpenScreen(pauseMenu);
        }

        private IEnumerator UnpauseDelayRoutine (bool shwView)
        {
            yield return null;
            Time.timeScale = 1;
        }
    }
}