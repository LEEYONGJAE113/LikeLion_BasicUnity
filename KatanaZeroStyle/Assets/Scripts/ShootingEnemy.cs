using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [Header("적 캐릭터 속성")]
    public float detectionRange = 10f; // 플레이어를 감지할 수 있는 최대 거리
    public float shootingInterval = 2f; // 미사일 발사 사이 대기 시간
    public GameObject missilePrefab;  // 미사일 프리팹

    [Header("참조 컴포넌트")]
    public Transform firePoint; // 미사일 발사할 위치
    private Transform player; // 플레이어 위치 정보
    private float shootTimer; // 발사 타이머
    private SpriteRenderer spriteRenderer; // 스프라이트 방향 전환용
    private Animator animator;

    void Start()
    {
        // 컴포넌트 초기화
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        shootTimer = shootingInterval; // 타이머 초기화
    }


    void Update()
    {
        if (player == null) { return; } // 플레이어 없으면 실행 x
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if(distanceToPlayer <= detectionRange)
        {
            // 플레이어 방향으로 스프라이트 회전
            spriteRenderer.flipX = player.position.x < transform.position.x; // 왼쪽에 있으면 flipX = true
            transform.GetChild(0).localPosition = new Vector3(-transform.GetChild(0).localPosition.x, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);

            // 미사일 발사 로직
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootingInterval;
            }
        }
    }

    // 미사일 발사 함수
    void Shoot()
    {
        // 미사일 생성
        GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);

        // 플레이어 방향으로 발사 방향 설정
        Vector2 direction = (player.position - firePoint.position).normalized;

        missile.GetComponent<EnemyMissile>().SetDirection(direction);

        missile.GetComponent<SpriteRenderer>().flipX = player.position.x < transform.position.x; // 왼쪽에 있으면 flipX = true
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    public void PlayDeathAnimation()
    {
        animator.SetBool("Death", true);
        // optional, 애니메이션 종료 후 오브젝트 제거를 위해, 임의로 프레임에 이벤트를 안 달고 유동적인 변화도 ok
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);        
    }
}
