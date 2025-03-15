using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public GameObject target; // 플레이어
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNormz;

    void Start()
    {
        // 플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        // A - B (B에서 A를 보는 벡터) 플레이어 - 미사일
        dir = target.transform.position - transform.position;
        // 방향 벡터만 구함
        dirNormz = dir.normalized;

        // transform.position = Vector3.MoveTowards(transform.position 
        // ,target.transform.position, Speed * Time.deltaTime);
    }

    void Update()
    {
        transform.Translate(dirNormz * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }
        Destroy(gameObject);
    }
}
