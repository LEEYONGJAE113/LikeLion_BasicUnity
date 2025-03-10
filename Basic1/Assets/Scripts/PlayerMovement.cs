using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;
    

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move* Speed * Time.deltaTime);
        
    }
}
