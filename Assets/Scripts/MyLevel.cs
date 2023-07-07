using Assets.Scripts.Core;
using Unity.VisualScripting;
using UnityEngine;

public class MyLevel : MyMonoBehavior
{
    public Transform PlayerSpawn;

    private void Start()
    {
        MyEventHandler.OnPlayerHitsTarget += OnPlayerHitsTarget;
    }

    private void OnPlayerHitsTarget(MyTarget target, PlayerController player)
    {
        MyEventHandler?.CallOnLevelCompleted(this);
    }


    private void OnDestroy()
    {
        if (MyEventHandler != null && !MyEventHandler.IsDestroyed())
            MyEventHandler.OnPlayerHitsTarget -= OnPlayerHitsTarget;
    }
}
