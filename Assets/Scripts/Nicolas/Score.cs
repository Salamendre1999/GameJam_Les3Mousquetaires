using System;
using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class Score : MonoBehaviour
    {
        
        public Text scoreText;
        public float scoreAmount;
        public float pointIncreasedPerSecond;

       
        // Start is called before the first frame update
        private void Start()
        {
            scoreAmount = 0f;
            pointIncreasedPerSecond = 1f;
        }
        // Update is called once per frame
       
        
        void Update()
        {
            

            scoreText.text = (int) scoreAmount + "Score";
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
            
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
