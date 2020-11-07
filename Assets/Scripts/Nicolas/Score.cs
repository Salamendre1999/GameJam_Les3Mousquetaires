using System;
using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class Score : MonoBehaviour
    {

        public Text TimerText;
        public bool playing = true;
        public int maxScore = 5000;

        private float Timer;

        public float scoreAmount =0f;
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
 /*
            int minute = Int32.Parse(TimerText.text.Substring(0, 2));
            scoreAmount = maxScore - minute;
            int seconde = Int32.Parse(TimerText.text.Substring(3, 5));
            scoreAmount = maxScore - seconde;
            int milli = Int32.Parse(TimerText.text.Substring(6, 8));
            scoreAmount = maxScore - milli;
*/
        }
    }
}
