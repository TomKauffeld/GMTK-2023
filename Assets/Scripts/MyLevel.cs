using Assets.Scripts.Core;
using Assets.Scripts.Levels;
using Assets.Scripts.Player;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MyLevel : MyMonoBehaviour
{
    public Transform PlayerSpawn;
    public bool Playing { get; private set; } = false;
    public bool Finished { get; private set; } = false;
    public bool Win { get; private set; } = false;


    public string Name;

    private Quaternion InitialRotation;

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

    public bool IsInsideBounds(Vector3 point)
    {
        return (transform.position - point).sqrMagnitude < 100 * 100;
    }

    public void CheckPlayerBounds(Vector3 player)
    {
        if (Finished || IsInsideBounds(player))
            return;
        Win = false;
        Finished = true;
    }



    protected override void Start()
    {
        base.Start();
        InitialRotation = transform.rotation;
        MyEventHandler.OnPlayerHitsTarget += OnPlayerHitsTarget;
        ResetLevel();
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

    public void ResetLevel()
    {
        Finished = false;
        Win = false;
        Playing = false;
        transform.rotation = InitialRotation;
    }
}
