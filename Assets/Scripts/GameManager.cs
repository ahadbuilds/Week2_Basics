using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject endPanel;
    public TMP_Text endText;
    public bool gameOver = false;

    void Start()
    {
        gameOver = false;

        if (endPanel != null)
        {
            endPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("EndPanel is not assigned.", this);
        }

        if (endText == null)
        {
            Debug.LogError("EndText is not assigned.", this);
        }
    }

    void Update()
    {
        if (!gameOver)
        {
            return;
        }

        if (Keyboard.current != null &&
            Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void EndGame(string message)
    {
        if (gameOver)
        {
            return;
        }

        gameOver = true;

        if (endText != null)
        {
            endText.text = message + "\nPress R to restart";
        }

        if (endPanel != null)
        {
            endPanel.SetActive(true);
        }

        Debug.Log(message);
    }
}