using Assets.Scripts.Core;
using UnityEngine.UI;

namespace Assets.Scripts.Menus
{
    public class MySettingsMenu : MyMenu
    {
        public Toggle InverseRotation;
        public bool inverse;

        protected override void Start()
        {
            base.Start();
            InverseRotation.isOn = MySettings.InverseRotation;
            InverseRotation.onValueChanged.AddListener(OnInverseRotation);
        }

        protected void OnEnable()
        {
            InverseRotation.isOn = MySettings.InverseRotation;
        }


        private void Update()
        {
            inverse = MySettings.InverseRotation;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (InverseRotation)
                InverseRotation.onValueChanged.RemoveListener(OnInverseRotation);
        }


        private void OnInverseRotation(bool value)
        {
            MySettings.InverseRotation = value;
        }
        public void OnBackClick()
        {
            GoBack();
        }
    }
}
