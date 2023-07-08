using Assets.Scripts.Core;
using Assets.Scripts.Core.Inputs;
using UnityEngine;

[RequireComponent(typeof(MyIdleInputHandler))]
public class BackgroundManager : MyMonoBehaviour
{
    private MyIdleInputHandler MyIdleInputHandler;

    protected override void Start()
    {
        base.Start();
        if (MyEventHandler)
            MyEventHandler.OnHitsWall += OnHitsWall;
        MyIdleInputHandler = GetComponent<MyIdleInputHandler>();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (MyEventHandler)
            MyEventHandler.OnHitsWall -= OnHitsWall;
    }

    private void OnHitsWall()
    {
        MyIdleInputHandler.Rotate = true;
    }
}
