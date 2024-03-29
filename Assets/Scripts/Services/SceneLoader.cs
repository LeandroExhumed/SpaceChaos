﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace LeandroExhumed.SpaceChaos.Services
{
    public static class SceneLoader
    {
        private const string GAMEPLAY = "Gameplay";
        private const string MAIN_MENU = "MainMenu";

        public static void LoadGameplayScene ()
        {
            LoadScene(GAMEPLAY);
        }

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