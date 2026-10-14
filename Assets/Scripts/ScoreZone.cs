using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int knockedDown = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            knockedDown = knockedDown + 1;
            Debug.Log("Crates knocked down: " + knockedDown);
            Destroy(other.gameObject, 1f);
        }
    }
}