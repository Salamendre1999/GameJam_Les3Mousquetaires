using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nicolas
{
    public class GameManager : Singleton<GameManager>
    {
            
    
        protected override void Initialize()
        {
        }
        protected override void Cleanup()
        {
        }
    
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
    }
}

