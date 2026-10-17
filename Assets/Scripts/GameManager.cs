using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timeLeft = 30f;
    public int winScore = 6;
    public ScoreZone zone;
    public TMP_Text timerText;
    public GameObject endPanel;
    public TMP_Text endText;
    public bool gameOver = false;

    void Start()
    {
        endPanel.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }

        timeLeft = timeLeft - Time.deltaTime;
        if (timeLeft < 0f)
        {
            timeLeft = 0f;
        }
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);

        if (timeLeft <= 10f)
        {
            timerText.color = Color.red;
        }

        if (zone.knockedDown >= winScore)
        {
            EndGame("YOU WIN!");
        }
        else if (timeLeft <= 0f)
        {
            EndGame("TIME'S UP!");
        }
    }

    void EndGame(string message)
    {
        gameOver = true;
        endText.text = message + "\nPress R to restart";
        endPanel.SetActive(true);
    }
}