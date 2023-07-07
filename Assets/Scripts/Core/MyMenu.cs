using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyMenu : MonoBehaviour
    {
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

        public bool ChangeMenu(string menuName)
        {
            if (MenuManager != null)
                return MenuManager.ChangeMenu(menuName);
            return false;
        }

        public bool ChangeMenu(ushort index)
        {
            if (MenuManager != null)
                return MenuManager.ChangeMenu(index);
            return false;
        }

        public bool ChangeMenu(MyMenu menu)
        {
            if (MenuManager != null)
                return MenuManager.ChangeMenu(menu);
            return false;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}