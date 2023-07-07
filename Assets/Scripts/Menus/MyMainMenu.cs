using Assets.Scripts.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    public class MyMainMenu : MyMenu
    {
        public MyAboutMenu AboutMenu;
        public MySettingsMenu SettingsMenu;
        public string GameScene;

        public void OnPlayClick()
        {
            SceneManager.LoadScene(GameScene, LoadSceneMode.Single);
        }

        public void OnContinueClick()
        {

        }

        public void OnSettingsClick()
        {
            ChangeMenu(SettingsMenu);
        }

        public void OnAboutClick()
        {
            ChangeMenu(AboutMenu);
        }

        public void OnExitClick() 
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
