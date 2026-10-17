using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameManager manager;

    void Update()
    {
        if (manager.gameOver)
        {
            return;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}