using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 5f; // 점프하는 힘
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // rigidbody : 물리효과를 추가
            // addforce : 오브젝트에 힘을 줌
            // forcemode.impulse : 순간적인 힘
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }
}
