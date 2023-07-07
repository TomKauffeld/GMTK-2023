using Assets.Scripts.Core;
using UnityEngine.Rendering;

namespace Assets.Scripts.Menus
{
    public class MyAboutMenu : MyMenu
    {
        public MyMenu ReturnMenu;


        public void OnBackClick()
        {
            ChangeMenu(ReturnMenu);
        }
    }
}
