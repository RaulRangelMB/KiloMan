using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public GameObject winGamePanel;
    public AudioSource gameMusicSource;
    public TextMeshProUGUI coinCounterText;
    private bool musicStopped = false;

    void Update()
    {
        coinCounterText.text = GameController.GetCollectedCount().ToString();

        if (GameController.gameOver)
        {
            endGamePanel.SetActive(true);
            StopGameMusicOnce();
            Time.timeScale = 0f;
        }

        if (GameController.gameWin)
        {
            winGamePanel.SetActive(true);
            StopGameMusicOnce();
            Time.timeScale = 0f;
        }
    }

    private void StopGameMusicOnce()
    {
        if (!musicStopped && gameMusicSource.isPlaying)
        {
            gameMusicSource.Stop();
            musicStopped = true;
        }
    }
}
