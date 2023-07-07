using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLevel : MonoBehaviour
{
    public Action OnGameFinished;

    public Transform PlayerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        MyTarget[] targets = GetComponentsInChildren<MyTarget>();
        foreach (MyTarget target in targets)
            target.OnPlayerHit += OnPlayerHitsTarget;
    }

    private void OnPlayerHitsTarget(PlayerController controller)
    {
        OnGameFinished?.Invoke();
    }

    private void OnDestroy()
    {
        MyTarget[] targets = GetComponentsInChildren<MyTarget>();
        foreach (MyTarget target in targets)
            target.OnPlayerHit -= OnPlayerHitsTarget;
    }
}
