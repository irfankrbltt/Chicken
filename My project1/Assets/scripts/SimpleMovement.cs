using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 100f;  // �leri-geri h�z
    public float turnSpeed = 100f; // D�nme h�z�
    public float jumpForce = 5f; // Z�plama g�c�
    private bool isGrounded = false; // Karakterin yere de�ip de�medi�ini kontrol eder

    void Update()
    {
        // Hareket ve d�n��
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(0, 0, move);
        transform.Rotate(0, turn, 0);

        // Yere bas�p basmad���n� kontrol et (Raycast ile)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Z�plama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
        }
    }
}
