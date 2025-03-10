using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveVector;
    float moveSpeed;
    float jumpVelocity;
    Rigidbody rb;
    void Start()
    {
        moveSpeed = 9.0f;
        jumpVelocity = 7.0f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float playerX = Input.GetAxis("Horizontal");
        float playerZ = Input.GetAxis("Vertical");
        moveVector = new Vector3(playerX, 0, playerZ);
        transform.position += moveVector * moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }

}
