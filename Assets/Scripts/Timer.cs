using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class Timer : MonoBehaviour
    {
        private Text _timeText;
        private bool _playing;
        private float _timer;

        public void Start()
        {
            _timeText = GetComponent<Text>();
            _playing = true;
        }

        private void Update()
        {
            if (_playing == true)
            {
                _timer += Time.deltaTime;
                int minutes = Mathf.FloorToInt((_timer / 60F));
                int seconds = Mathf.FloorToInt((_timer % 60F));
                int milliseconds = Mathf.FloorToInt((_timer * 100F) % 100F);
                _timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" +
                                milliseconds.ToString("00");
                
            }
        }
    }
}
