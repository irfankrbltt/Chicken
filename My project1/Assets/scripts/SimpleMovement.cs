using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 100f;  // Ýleri-geri hýz
    public float turnSpeed = 100f; // Dönme hýzý
    public float jumpForce = 5f; // Zýplama gücü
    private bool isGrounded = false; // Karakterin yere deðip deðmediðini kontrol eder

    void Update()
    {
        // Hareket ve dönüþ
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(0, 0, move);
        transform.Rotate(0, turn, 0);

        // Yere basýp basmadýðýný kontrol et (Raycast ile)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Zýplama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
        }
    }
}
