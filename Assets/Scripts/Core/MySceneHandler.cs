using UnityEngine.SceneManagement;

namespace Assets.Scripts.Core
{
    public class MySceneHandler : MyMonoBehaviour
    {
        public string MainMenuScene;
        public string MainGameScene;

        protected override void Start()
        {
            base.Start();
            if (MyEventHandler)
            {
                MyEventHandler.OnChangeToMainGame += OnChangeToMainGame;
                MyEventHandler.OnChangeToMainMenu += OnChangeToMainMenu;
            }
        }

        private void OnChangeToMainMenu()
        {
            SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
        }

        private void OnChangeToMainGame()
        {
            SceneManager.LoadScene(MainGameScene, LoadSceneMode.Single);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (MyEventHandler)
            {
                MyEventHandler.OnChangeToMainGame -= OnChangeToMainGame;
                MyEventHandler.OnChangeToMainMenu -= OnChangeToMainMenu;
            }
        }
    }
}
