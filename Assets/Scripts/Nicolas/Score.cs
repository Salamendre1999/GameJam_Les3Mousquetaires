using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class Score : MonoBehaviour
    {

        public Text TimerText;
        public bool playing;

        private float Timer;
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            if (playing == true)
            {

                Timer += Time.deltaTime;
                int minutes = Mathf.FloorToInt(Timer / 60f);
                int seconds = Mathf.FloorToInt(Timer % 60f);
                int milliseconds = Mathf.FloorToInt((Timer * 100f) % 100f);
                TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" +
                                 milliseconds.ToString("00");
            }
        }
    }
}
