using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(Button))]
    public class MyContinueButton : MyMonoBehaviour
    {
        private Button Button;

        protected override void Start()
        {
            base.Start();
            Button = GetComponent<Button>();
            Button.interactable = MySettings.NextLevel > 0;
        }
    }
}