using UnityEngine;
using TMPro;

public class ScoreZone : MonoBehaviour
{
    public int knockedDown = 0;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            knockedDown = knockedDown + 1;
            UpdateText();
            Destroy(other.gameObject, 1f);
        }
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + knockedDown;
    }
}