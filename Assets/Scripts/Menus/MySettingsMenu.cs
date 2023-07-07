using Assets.Scripts.Core;

namespace Assets.Scripts.Menus
{
    public class MySettingsMenu : MyMenu
    {
        public MyMenu ReturnMenu;


        public void OnBackClick()
        {
            ChangeMenu(ReturnMenu);
        }
    }
}
