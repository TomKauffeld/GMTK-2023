using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyMenu : MyMonoBehaviour
    {

        public MyMenu ReturnMenu { get; set; }

        private MyMenuManager menuManager = null;
        public MyMenuManager MenuManager
        {
            get
            {
                if (menuManager == null)
                    menuManager = GetComponentInParent<MyMenuManager>();
                return menuManager;
            }
        }

        public bool ChangeMenu(string menuName, MyMenu returnMenu = null)
        {
            if (MenuManager != null)
                return MenuManager.ChangeMenu(menuName, returnMenu);
            return false;
        }

        public bool ChangeMenu(ushort index, MyMenu returnMenu = null)
        {
            if (MenuManager != null)
                return MenuManager.ChangeMenu(index, returnMenu);
            return false;
        }

        public bool ChangeMenu(MyMenu menu, MyMenu returnMenu = null)
        {
            if (MenuManager != null)
                return MenuManager.ChangeMenu(menu, returnMenu);
            return false;
        }

        public bool GoBack()
        {
            return ChangeMenu(ReturnMenu, this);
        }
    }
}