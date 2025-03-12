using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    [SerializeField]
    int hp;

    void Start()
    {
        
    }

    void Update()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        transform.Translate(0f, -distanceY, 0f); // 아래로 움직이게끔
    }

    // 화면 밖으로 나가서 카메라에서 보이지 않으면 호출
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Damaged();
        }
    }
    public void Damaged()
    {
        if (hp > 0)
        {
            --hp;
        }
        if (hp <= 0)
        {
            SoundManager.Instance.PlayDieSound();
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
