using Assets.Scripts.Core;
using Assets.Scripts.Core.Inputs;
using Assets.Scripts.Player;
using System;
using System.Collections;
using UnityEngine;

public class MyGameController : MyMonoBehaviour
{
    public MyLevel[] Levels = Array.Empty<MyLevel>();
    public PlayerController Player;
    public Coroutine CurrentLevelLayout = null;

    public MyLevel LoadedLevel { get; private set; } = null;
    private int level = 0;

    protected override void Start()
    {
        base.Start();
        MyEventHandler.OnLevelCompleted += OnLevelCompleted;
        MyEventHandler.OnLevelLoaded += OnLevelLoaded;
        MyEventHandler.OnGameFinished += OnGameFinished;
        LoadLevel(MySettings.NextLevel);
        MyEventHandler.Play();
    }

    private void OnGameFinished()
    {
        StartCoroutine(DisplayEndGame());
    }

    private IEnumerator DisplayEndGame()
    {
        yield return new WaitForMessage(MyEventHandler.ShowMessage("You finished the game, sadly we don't have any more levels"));
        MyEventHandler.LoadMainMenu();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (MyEventHandler)
        {
            MyEventHandler.OnLevelCompleted -= OnLevelCompleted;
            MyEventHandler.OnLevelLoaded -= OnLevelLoaded;
        }
    }

    private void Update()
    {
        if (MyInputHandler.IsActionDown(Actions.PAUSE))
        {
            if (Paused)
                MyEventHandler.Play();
            else
                MyEventHandler.Pause();
        }

        Player.Freeze = LoadedLevel == null || LoadedLevel.Finished || !LoadedLevel.Playing;

        if (LoadedLevel != null && LoadedLevel.Playing && !LoadedLevel.Finished && !Player.Freeze)
            LoadedLevel.CheckPlayerBounds(Player.transform.position);
    }

    private void OnLevelCompleted(MyLevel level)
    {
        if (!LoadLevel(this.level + 1))
            MyEventHandler.CallOnGameFinished();
    }

    public bool LoadLevel(int level)
    {
        if (level >= 0 && level < Levels.Length)
        {
            LoadLevel(Levels[level]);
            this.level = level;
            MySettings.NextLevel = level;
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
            level.ResetLevel();


            if (LoadedLevel.TryGetComponent(out LevelController levelController))
                levelController.Target = Player.transform;

            Player.transform.position = LoadedLevel.PlayerSpawn.position;

            if (Player.TryGetComponent(out Rigidbody rigidbody))
                ResetRigidBody(rigidbody);


            Player.gameObject.SetActive(true);

            yield return new WaitForMessage(MyEventHandler.ShowMessage("Level " + level.Name));

            yield return StartCoroutine(level.LevelLayout());
        }
        while (!level.Win);

        if (MyEventHandler)
            MyEventHandler.CallOnLevelCompleted(level);
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
