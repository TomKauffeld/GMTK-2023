using Assets.Scripts.Core;
using System;

public class MyGameController : MyMonoBehavior
{
    public MyLevel[] Levels = Array.Empty<MyLevel>();
    public PlayerController Player;


    public MyLevel LoadedLevel { get; private set; } = null;
    private int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        MyEventHandler.OnLevelCompleted += OnLevelCompleted;
        LoadLevel(0);
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

    public void UnloadLevel()
    {
        if (LoadedLevel == null)
            return;
        Destroy(LoadedLevel.gameObject); 
        LoadedLevel = null;
        Player.gameObject.SetActive(false);
    }

}
