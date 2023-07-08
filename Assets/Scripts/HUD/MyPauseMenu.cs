using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.HUD
{
    public class MyPauseMenuController : MyMonoBehaviour
    {
        public GameObject PauseMenu;

        protected override void OnPause()
        {
            base.OnPause();
            PauseMenu.SetActive(true);
        }

        protected override void OnPlay()
        {
            base.OnPlay();
            PauseMenu.SetActive(false);
        }
    }
}
