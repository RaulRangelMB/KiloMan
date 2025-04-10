using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{

    // Video guia utilizado para a criação do cronometro
    // https://www.youtube.com/watch?v=POq1i8FyRyQ
    [SerializeField] TextMeshProUGUI timerText;
    float time;
    void Update()
    {
        time += Time.deltaTime;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);    
    }
}
