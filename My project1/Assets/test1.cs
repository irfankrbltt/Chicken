using UnityEngine;

// Ensure we have a CharacterController
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f; // Degrees per second

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        // Get references to needed components
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from WASD or arrow keys
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Combine into a direction vector
        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;

        // Check if we're moving enough to consider "walking"
        if (moveDir.magnitude >= 0.1f)
        {
            // Set walking animation
            animator.SetBool("IsWalking", true);

            // Smoothly rotate towards movement direction
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the character
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Switch to idle animation
            animator.SetBool("IsWalking", false);
        }

        // Apply basic gravity if not grounded
        if (!controller.isGrounded)
        {
            controller.Move(Physics.gravity * Time.deltaTime);
        }
    }
}
