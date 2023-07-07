using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyDisabledOnWeb : MonoBehaviour
    {
#if PLATFORM_WEBGL && !UNITY_EDITOR
        private void Start()
        {
            gameObject.SetActive(false);
        }
#endif
    }
}
