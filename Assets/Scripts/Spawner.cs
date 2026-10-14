using UnityEngine;
using UnityEngine.InputSystem;
public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}