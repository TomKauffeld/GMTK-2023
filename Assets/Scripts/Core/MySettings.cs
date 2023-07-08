using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MySettings : MonoBehaviour
    {
        private static int nextLevel = 0;
        private static bool inverseRotation = false;

        public bool InverseRotation { get => inverseRotation; set => inverseRotation = value; }
        public int NextLevel { get => nextLevel; set => nextLevel = value; }
    }
}
