using SpaceChaos.Constants;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceChaos.HUD.Buttons {
    /// <summary>
    /// Command for loading a given scene asynchronously.
    /// </summary>
    /// <seealso cref="SpaceChaos.HUD.Buttons.ButtonCommand" />
    [AddComponentMenu("SpaceChaos/HUD/Buttons/SceneLoader")]
    public class SceneLoader : ButtonCommand {
        /// <summary>Which scene this button will load.</summary>
        [SerializeField]
        private GameScene sceneToLoad;

        /// <summary>Screen shown while loading another scene.</summary>
        [SerializeField]
        private GameObject loadingScreen;

        /// <summary>
        /// Loads the requested scene asynchronously.
        /// </summary>
        public override void execute () {
            base.execute();

            Time.timeScale = 1;
            switch (sceneToLoad) {
                case GameScene.MainMenu:
                    StartCoroutine(loadAsync(SceneNames.MAIN_MENU));
                    break;
                case GameScene.GameSection:
                    StartCoroutine(loadAsync(SceneNames.GAME_SECTION));
                    break;
                case GameScene.Current:
                    audioManager.setMusicVolume(1);
                    StartCoroutine(loadAsync(SceneManager.GetActiveScene().name));
                    break;
            }
        }

        /// <summary>
        /// Loads a scene using an asynchronous operation.
        /// </summary>
        /// <param name="sceneName">Name of the scene.</param>
        /// <returns></returns>
        private IEnumerator loadAsync (string sceneName) {
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
            loadingScreen.SetActive(true);
            while (!async.isDone) {
                yield return null;
            }
        }
    } 
}