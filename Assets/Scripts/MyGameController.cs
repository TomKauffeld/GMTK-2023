using Assets.Scripts.Core;
using System;
using System.Collections;
using UnityEngine;

public class MyGameController : MyMonoBehavior
{
    public MyLevel[] Levels = Array.Empty<MyLevel>();
    public PlayerController Player;
    public Coroutine CurrentLevelLayout = null;
    private Vector3 LastPos = Vector3.zero;


    public MyLevel LoadedLevel { get; private set; } = null;
    private int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        MyEventHandler.OnLevelCompleted += OnLevelCompleted;
        MyEventHandler.OnLevelLoaded += OnLevelLoaded;
        LoadLevel(0);
    }

    private void Update()
    {
        if (LoadedLevel == null || LoadedLevel.Finished)
            Player.transform.position = LastPos;
        else
            LastPos = Player.transform.position;
    }

    private void OnLevelCompleted(MyLevel level)
    {
        MyEventHandler.ShowMessage("We Won");
        if (!LoadLevel(this.level + 1))
            MyEventHandler.CallOnGameFinished();
    }

    public bool LoadLevel(int level)
    {
        if (level >= 0 && level < Levels.Length)
        {
            LoadLevel(Levels[level]);
            this.level = level;
            return true;
        }
        UnloadLevel();
        return false;
    }


    public void LoadLevel(MyLevel level)
    {
        UnloadLevel();
        LoadedLevel = Instantiate(level, transform);
        if (LoadedLevel.TryGetComponent(out LevelController levelController))
            levelController.Target = Player.transform;
        Player.transform.position = LoadedLevel.PlayerSpawn.position;
        Player.gameObject.SetActive(true);
        MyEventHandler.CallOnLevelLoaded(LoadedLevel);
    }

    private void OnLevelLoaded(MyLevel level)
    {
        if (CurrentLevelLayout != null)
            StopCoroutine(CurrentLevelLayout);
        CurrentLevelLayout = StartCoroutine(RunLevel(level));
    }

    private IEnumerator RunLevel(MyLevel level)
    {
        do
        {
            if (LoadedLevel.TryGetComponent(out LevelController levelController))
                levelController.Target = Player.transform;
            Player.transform.position = LoadedLevel.PlayerSpawn.position;
            if (Player.TryGetComponent(out Rigidbody rigidbody))
                ResetRigidBody(rigidbody);
            Player.gameObject.SetActive(true);
            yield return StartCoroutine(level.LevelLayout());
        }
        while (!level.Win);
        MyEventHandler?.CallOnLevelCompleted(level);
    }

    private void ResetRigidBody(Rigidbody rigidbody)
    {
        rigidbody.ResetInertiaTensor();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    public void UnloadLevel()
    {
        if (LoadedLevel == null)
            return;
        if (CurrentLevelLayout != null)
            StopCoroutine(CurrentLevelLayout);
        CurrentLevelLayout = null;
        Destroy(LoadedLevel.gameObject); 
        LoadedLevel = null;
        if (Player.TryGetComponent(out Rigidbody rigidbody))
            ResetRigidBody(rigidbody);
        Player.gameObject.SetActive(false);
    }

}
