using UnityEngine;
using UnityEngine.SceneManagement;

namespace LeandroExhumed.SpaceChaos
{
    public static class SceneLoader
    {
        private const string MAIN_MENU = "MainMenu";

        public static void ReloadScene ()
        {
            LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void LoadMainMenu ()
        {
            LoadScene(MAIN_MENU);
        }

        private static void LoadScene (string sceneName)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
        }
    }
}