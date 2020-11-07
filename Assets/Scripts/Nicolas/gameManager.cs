using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nicolas
{
    public class GameManager : Singleton<GameManager>
    {
        

        public void NewGame()
        {
            LoadScene("Level1");
           
        }

        public void GameOver()
        {
            LoadScene("GameOver");
        }

        public void MainMenu()
        {
            LoadScene("MainMenu");
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            var asyncload = SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        protected override void Cleanup()
        {
            throw new System.NotImplementedException();
        }

        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
