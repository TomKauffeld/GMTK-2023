using Assets.Scripts.Core;

namespace Assets.Scripts.Menus
{
    public class MyMainMenu : MyMenu
    {
        public MyAboutMenu AboutMenu;
        public MySettingsMenu SettingsMenu;

        public void OnPlayClick()
        {

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
        }
    }
}
