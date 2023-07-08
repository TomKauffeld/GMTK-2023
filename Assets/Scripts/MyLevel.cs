using Assets.Scripts.Core;
using Assets.Scripts.Levels;
using Assets.Scripts.Player;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MyLevel : MyMonoBehaviour
{
    public Transform PlayerSpawn;
    public bool Playing { get; private set; } = false;
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

    protected void StartPlaying()
    {
        Playing = true;
    }


    protected WaitForLevelFinish WaitForEnd()
    {
        return new WaitForLevelFinish(this);
    }

    public virtual IEnumerator LevelLayout()
    {
        StartPlaying();
        return WaitForEnd();
    }



    protected override void Start()
    {
        base.Start();
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


    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (MyEventHandler != null && !MyEventHandler.IsDestroyed())
            MyEventHandler.OnPlayerHitsTarget -= OnPlayerHitsTarget;
    }
}
