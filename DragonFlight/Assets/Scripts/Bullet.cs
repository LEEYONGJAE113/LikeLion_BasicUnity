using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    public GameObject exposion;

    void Update()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        transform.Translate(0f, distanceY, 0f);
    }

    // 화면 밖으로 나가서 카메라에서 보이지 않으면 호출
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Instantiate(exposion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    
}
