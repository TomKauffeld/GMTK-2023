using Assets.Scripts.Core;
using UnityEngine;

public class MyTarget : MyMonoBehavior
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController controller))
            MyEventHandler?.CallOnPlayerHitsTarget(this, controller);
    }
}
