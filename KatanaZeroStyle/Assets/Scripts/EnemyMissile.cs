using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 3f;
    public int damage = 10;
    public Vector2 direction;
    bool isReflect = false;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    public void Reflected()
    {
        isReflect = true;
    }

    void Update()
    {
        float timeScale = TimeController.Instance.GetTimeScale();
        transform.Translate(direction * speed * Time.deltaTime * timeScale);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // 플레이어 데미지 로직 추가
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Enemy") && isReflect)
        {
            ShootingEnemy enemy = collision.GetComponent<ShootingEnemy>();
            enemy?.PlayDeathAnimation();
            
            // 미사일 제거
            Destroy(gameObject);
        }
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
