using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameController : MonoBehaviour
{
    public MyLevel[] Levels = Array.Empty<MyLevel>();
    public PlayerController Player;


    public MyLevel LoadedLevel { get; private set; } = null;
    private int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLevelWon()
    {
        Debug.Log("WE WON");
        LoadLevel(level + 1);
    }

    public void LoadLevel(int level)
    {
        Debug.Log("Load level " + level);
        if (level >= 0 && level < Levels.Length)
        {
            LoadLevel(Levels[level]);
            this.level = level;
        }
        else
            UnloadLevel();
    }


    public void LoadLevel(MyLevel level)
    {
        UnloadLevel();
        Debug.Log("Load Level");
        LoadedLevel = Instantiate(level, transform);
        LoadedLevel.OnGameFinished += OnLevelWon;
        if (LoadedLevel.TryGetComponent(out LevelController levelController))
            levelController.Target = Player.transform;
        Player.transform.position = LoadedLevel.PlayerSpawn.position;
        Player.gameObject.SetActive(true);
    }

    public void UnloadLevel()
    {
        Debug.Log("Unload Level");
        if (LoadedLevel == null)
            return;
        LoadedLevel.OnGameFinished -= OnLevelWon;
        Destroy(LoadedLevel.gameObject); 
        LoadedLevel = null;
        Player.gameObject.SetActive(false);
    }

}
