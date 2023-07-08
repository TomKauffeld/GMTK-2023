using Assets.Scripts.Core;
using Assets.Scripts.Player;
using UnityEngine;

public class MyTarget : MyMonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController controller))
            MyEventHandler?.CallOnPlayerHitsTarget(this, controller);
    }
}
