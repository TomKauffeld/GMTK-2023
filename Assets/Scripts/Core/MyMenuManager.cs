using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyMenuManager : MonoBehaviour
    {
        public const ushort NO_MENU = 0;
        public ushort StartingMenu = NO_MENU;
        public MyMenu[] Menus = Array.Empty<MyMenu>();

        public MyMenu CurrentMenu { get; private set; } = null;


        void Start()
        {
            foreach (MyMenu menue in GetComponentsInChildren<MyMenu>())
                menue.gameObject.SetActive(false);
            ChangeMenu(StartingMenu);
        }

        public bool ChangeMenu(MyMenu menu, MyMenu returnMenu = null)
        {
            if (menu == null)
                return ChangeMenu(NO_MENU, returnMenu);
            return LoadMenu(menu, returnMenu);
        }

        public ushort FindMenu(string menuName)
        {
            for (int i = 0; i < Menus.Length; ++i)
                if (Menus[i].name == menuName)
                    return (ushort)(i + 1);
            return NO_MENU;
        }

        public bool ChangeMenu(string menuName, MyMenu returnMenu = null)
        {
            if (menuName == null || menuName.Length == 0)
                return ChangeMenu(NO_MENU, returnMenu);
            ushort index = FindMenu(menuName);
            if (index == NO_MENU)
                return false;
            return ChangeMenu(index, returnMenu);
        }

        public bool ChangeMenu(ushort index, MyMenu returnMenu = null)
        {
            if (index < 1)
            {
                UnloadMenu();
                return true;
            }
            return LoadMenu((ushort)(index - 1), returnMenu);
        }

        protected bool LoadMenu(ushort index, MyMenu returnMenu = null)
        {
            if (index >= Menus.Length)
                return false;
            return LoadMenu(Menus[index], returnMenu);
        }

        protected bool LoadMenu(MyMenu menu, MyMenu returnMenu = null)
        {
            UnloadMenu();
            CurrentMenu = menu;
            CurrentMenu.gameObject.SetActive(true);
            CurrentMenu.ReturnMenu = returnMenu;
            return true;
        }

        protected void UnloadMenu()
        {
            if (CurrentMenu != null)
            {
                CurrentMenu.gameObject.SetActive(false);
                CurrentMenu = null;
            }
        }
    }
}