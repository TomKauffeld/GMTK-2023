using Assets.Scripts.Core;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    public class MyPauseMenu : MyMenu
    {
        public MyAboutMenu AboutMenu;
        public MySettingsMenu SettingsMenu;
        public string MainMenuScene;

        public void OnReturnClick()
        {
            MyEventHandler.LoadMainMenu();
        }

        public void OnContinueClick()
        {
            MyEventHandler.Play();
        }

        public void OnSettingsClick()
        {
            ChangeMenu(SettingsMenu, this);
        }

        public void OnAboutClick()
        {
            ChangeMenu(AboutMenu, this);
        }
    }
}
