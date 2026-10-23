using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public GameManager manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (manager != null)
            {
                manager.EndGame("YOU WIN!");
            }
            else
            {
                Debug.LogError("GameManager is not assigned to GoalZone.", this);
            }
        }
    }
}