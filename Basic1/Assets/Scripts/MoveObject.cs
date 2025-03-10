using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float Speed = 5.0f;

    void Update()
    {
        // Vector3 a = Vector3.right;

        // // 키 입력에 따른 이동
        // float move = Input.GetAxis("Horizontal");
        // // 방향 * 스피드 * 델타타임(프레임보정, 안곱하면 존나게 튀어나감)
        // transform.Translate(Vector3.right * move * Speed * Time.deltaTime);

        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));

        // transform.position += move * Speed * Time.deltaTime;
        
    }
}
