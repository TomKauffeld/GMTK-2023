using Assets.Scripts.Core;
using UnityEditor;

namespace Assets.Scripts.Menus
{
    public class MyMainMenu : MyMenu
    {
        public MyAboutMenu AboutMenu;
        public MySettingsMenu SettingsMenu;
        public string GameScene;

        public void OnPlayClick()
        {
            MySettings.NextLevel = 0;
            MyEventHandler.LoadMainGame();
        }

        public void OnContinueClick()
        {
            MyEventHandler.LoadMainGame();
        }

        public void OnSettingsClick()
        {
            ChangeMenu(SettingsMenu, this);
        }

        public void OnAboutClick()
        {
            ChangeMenu(AboutMenu, this);
        }

        public void OnExitClick() 
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif !PLATFORM_WEBGL
            Application.Quit();
#endif
        }
    }
}
