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
    
        public void PlayGame()
        {
            LoadScene("MainStage");
                
        }
    
        public void GameOver()
        {
            LoadScene("GameOver");
        }
    
        public void MainMenu()
        {
            LoadScene("MainMenu");
        }
        
         public void Win()
         {
             LoadScene("Win");
         }
         public void Settings() {
             LoadScene("Settings");
         }
         
         
        
        
    
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            var asyncload = SceneManager.LoadSceneAsync(sceneName);
        }
    
        
    }
}

