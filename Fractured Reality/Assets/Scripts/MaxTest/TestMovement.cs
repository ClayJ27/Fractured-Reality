using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float MoveSpeed = 5f; // The speed at which the player moves
    bool CanJump;
    private InputAction MoveAction; // The input action that controls player movement
    private Rigidbody2D rb; // The Rigidbody2D component attached to the player
    private Vector2 MoveInput; // The current movement input from the player


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction = InputSystem.actions.FindAction("Move"); // Find the "Move" action in the Input System
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        rb.freezeRotation = true;
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = MoveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Move the player based on the input and move speed
        rb.linearVelocity = new Vector2(MoveInput.x * MoveSpeed, rb.linearVelocity.y);
    }
}