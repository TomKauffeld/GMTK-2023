using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyMenuManager : MonoBehaviour
    {
        public const ushort NO_MENU = 0;
        public ushort StartingMenu = NO_MENU;
        public MyMenu[] Menus = Array.Empty<MyMenu>();


        public ushort CurrentMenuIndex { get; private set; } = NO_MENU;
        public MyMenu CurrentMenu { get; private set; } = null;


        void Start()
        {
            ChangeMenu(StartingMenu);
        }

        public bool ChangeMenu(MyMenu menu)
        {
            if (menu == null)
                return ChangeMenu(NO_MENU);
            return ChangeMenu(menu.name);
        }

        public ushort FindMenu(string menuName)
        {
            for (int i = 0; i < Menus.Length; ++i)
                if (Menus[i].name == menuName)
                    return (ushort)(i + 1);
            return NO_MENU;
        }

        public bool ChangeMenu(string menuName)
        {
            if (menuName == null || menuName.Length == 0)
                return ChangeMenu(NO_MENU);
            ushort index = FindMenu(menuName);
            if (index == NO_MENU)
                return false;
            return ChangeMenu(index);
        }

        public bool ChangeMenu(ushort index)
        {
            UnloadMenu();
            if (index < 1)
                return true;
            return LoadMenu((ushort)(index - 1));
        }

        protected bool LoadMenu(ushort index)
        {
            if (index >= Menus.Length)
                return false;
            CurrentMenu = Instantiate(Menus[index], transform);
            CurrentMenuIndex = index;
            return true;
        }

        protected void UnloadMenu()
        {
            CurrentMenuIndex = NO_MENU;

            if (CurrentMenu != null)
            {
                Destroy(CurrentMenu.gameObject);
                CurrentMenu = null;
            }
        }
    }
}