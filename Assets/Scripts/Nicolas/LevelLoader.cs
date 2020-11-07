using UnityEngine;

namespace Nicolas
{
    public class LevelLoader : MonoBehaviour
    {
        public void Load(string levelName)
        {
            GameManager.Instance.LoadScene(levelName);
        }
        

    }
}
