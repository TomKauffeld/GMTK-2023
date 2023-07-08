using Assets.Scripts.Core;
using Assets.Scripts.Levels;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MyLevel : MyMonoBehavior
{
    public Transform PlayerSpawn;
    public bool Finished { get; private set; } = false;
    public bool Win { get; private set; } = false;


    protected WaitForMessage ShowMessage(string message, float timeout = 5, bool evenIfFinished = false)
    {
        if (evenIfFinished)
            return new WaitForMessage(MyEventHandler.ShowMessage(message, timeout));
        else if (!Finished)
            return new WaitForMessage(MyEventHandler.ShowMessage(message, timeout), WaitForEnd());
        return null;
    }

    protected WaitForLevelFinish WaitForEnd()
    {
        return new WaitForLevelFinish(this);
    }

    public virtual IEnumerator LevelLayout()
    {
        return WaitForEnd();
    }



    private void Start()
    {
        Win = false;
        Finished = false;
        MyEventHandler.OnPlayerHitsTarget += OnPlayerHitsTarget;
    }

    private void OnPlayerHitsTarget(MyTarget target, PlayerController player)
    {
        if (!Finished)
        {
            Finished = true;
            Win = true;
        }
    }


    private void OnDestroy()
    {
        if (MyEventHandler != null && !MyEventHandler.IsDestroyed())
            MyEventHandler.OnPlayerHitsTarget -= OnPlayerHitsTarget;
    }
}
