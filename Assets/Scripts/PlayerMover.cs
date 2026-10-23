using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -20f;
    public GameManager manager;

    private CharacterController controller;
    private float verticalSpeed = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (manager != null && manager.gameOver)
        {
            return;
        }
        // Prevent errors if no keyboard is detected.
        if (Keyboard.current == null)
            return;

        float x = 0f;
        float z = 0f;

        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;
        if (Keyboard.current.sKey.isPressed) z = -1f;
        if (Keyboard.current.wKey.isPressed) z = 1f;

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        if (controller.isGrounded && verticalSpeed < 0f)
        {
            verticalSpeed = -2f;
        }

        verticalSpeed += gravity * Time.deltaTime;

        Vector3 move = direction * speed;
        move.y = verticalSpeed;

        controller.Move(move * Time.deltaTime);
    }
}