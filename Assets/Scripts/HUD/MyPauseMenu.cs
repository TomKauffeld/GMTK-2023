using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.HUD
{
    public class MyPauseMenuController : MyMonoBehaviour
    {
        public MyMenuManager PauseMenu;

        protected override void OnPause()
        {
            base.OnPause();
            PauseMenu.ChangeMenu(1);
        }

        protected override void OnPlay()
        {
            base.OnPlay();
            PauseMenu.ChangeMenu(0);
        }
    }
}
