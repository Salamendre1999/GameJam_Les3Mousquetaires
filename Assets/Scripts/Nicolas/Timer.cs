using System;
using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class Timer : MonoBehaviour
    {
        public Text timeText;
        public bool playing;
        public float timer;

        private void StartGame()
        {
            playing = true;
        }

        private void Update()
        {
            if (playing == true)
            {
                timer += Time.deltaTime;
                int minutes = Mathf.FloorToInt((timer / 60F));
                int seconds = Mathf.FloorToInt((timer % 60F));
                int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
                timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" +
                                milliseconds.ToString("00");
                
            }
        }
    }
}
