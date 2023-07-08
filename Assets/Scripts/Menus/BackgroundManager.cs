using Assets.Scripts.Core;
using Assets.Scripts.Core.Inputs;
using UnityEngine;

[RequireComponent(typeof(MyIdleInputHandler))]
public class BackgroundManager : MyMonoBehaviour
{
    public float WaitUntilRotate = 1;

    private MyIdleInputHandler MyIdleInputHandler;
    private float timeUntilRotate = float.NaN;

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
        timeUntilRotate = WaitUntilRotate;
    }

    private void Update()
    {
        if (!float.IsNaN(timeUntilRotate))
        {
            timeUntilRotate -= Time.deltaTime;
            if (timeUntilRotate < 0)
            {
                MyIdleInputHandler.Rotate = true;
                timeUntilRotate = float.NaN;
            }
        }
    }
}
