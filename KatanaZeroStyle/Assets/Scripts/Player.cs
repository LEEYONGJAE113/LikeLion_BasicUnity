using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region player stat
    [Header("플레이어 스탯")]
    public float power = 15;
    public float speed = 5;
    public float jumpUp = 27;
    float attackCooldown = 0.582f;
    bool isAttacking = false;
    public Vector3 direction;
    #endregion
    
    #region objects
    [Header("오브젝트")]
    public GameObject Slash;
    public GameObject shadow1;
    List<GameObject> sh = new List<GameObject>();
    public GameObject hitLazer;
    public GameObject JDust;
    public GameObject WallDust;
    #endregion

    #region Components
    // bool bJump = false;
    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;
    #endregion

    #region 벽점프
    public Transform WallChk;
    public float WallChkDistance;
    public LayerMask wLayer;
    bool isWall;
    public float SlidingSpeed;
    public float WallJumpPower;
    public bool IsWallJump;
    float isRight = 1;
    #endregion

    const float GROUND_CHECK_DISTANCE = 0.7f;
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        // 시간 조절 입력 체크 (왼 쉬프트를 누르면 슬로우 모션 시작)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // 포스트 프로세싱 화면 효과
            TimeController.Instance.SetSlowMotion(true);
        }

        if (!IsWallJump)
        {
            KeyInput();
            Move();
        }

        isWall = Physics2D.Raycast(WallChk.position, Vector2.right * isRight, WallChkDistance, wLayer);
        pAnimator.SetBool("Grab", isWall);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (pAnimator.GetBool("Jump") == false)
            {
                Jump();
                pAnimator.SetBool("Jump", true);
            }
        }

        if(isWall)
        {
            IsWallJump = false;
            // 벽점프상태
            pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocityX, pRig2D.linearVelocityY * SlidingSpeed);
            // 벽을 잡고있는 상태에서 점프
            if(Input.GetKeyDown(KeyCode.W))
            {
                IsWallJump = true;

                GameObject dust = Instantiate(WallDust, transform.position - new Vector3(0.3f * isRight, 0,  0), Quaternion.identity);
                dust.GetComponent<SpriteRenderer>().flipX = !sp.flipX;

                Invoke("FreezeX", 0.3f);

                // 물리
                pRig2D.linearVelocity = new Vector2(-isRight * WallJumpPower, 0.9f * WallJumpPower);

                sp.flipX = !sp.flipX;
                isRight = -isRight;
            }
        }
    }

    void FreezeX()
    {
        IsWallJump = false;
    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal"); // -1   0   1

        if(direction.x <0)
        {
            //left
            sp.flipX = true;
            pAnimator.SetBool("Run", true);

            isRight = -1;

            foreach (var item in sh)
            {
                item.GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }

        }
        else if(direction.x >0)
        {
            //right
            sp.flipX = false;
            pAnimator.SetBool("Run", true);

            isRight = 1;

            foreach (var item in sh)
            {
                item.GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }
        }
        else if(direction.x == 0)
        {
            pAnimator.SetBool("Run", false);

            for (int i = 0; i < sh.Count; ++i)
            {
                Destroy(sh[i]);
                sh.RemoveAt(i);
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (isAttacking) { return; }

            pAnimator.SetTrigger("Attack");
            Instantiate(hitLazer, transform.position, Quaternion.identity);
            StartCoroutine(DelayingAttack());
        }

    }

    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Debug.DrawRay(pRig2D.position, Vector3.down, new Color(0, 1, 0));
    
        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position, Vector3.down, GROUND_CHECK_DISTANCE, LayerMask.GetMask("Ground"));

        CheckGroundedState(rayHit);
        // if(Physics2D.Raycast(pRig2D.position, Vector3.down, 1, LayerMask.GetMask("Step")))
        // {
        //     pRig2D.gravityScale = 0f;
        // }
        // else
        // {
        //     pRig2D.gravityScale = 1;
        // }
    }

    public void Jump()
    {
        JumpingDust();

        pRig2D.linearVelocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
    }

    public void SlashAttack()
    {
        /*GameObject slash = */Instantiate(Slash, transform.position, Quaternion.identity);
        // slash.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        if(sp.flipX == false)
        {
            pRig2D.AddForce(Vector2.right * power ,ForceMode2D.Impulse);
        }
        else
        {
            pRig2D.AddForce(Vector2.left * power ,ForceMode2D.Impulse);
        }
    }

    public void RunShadow()
    {
        if (sh.Count < 6)
        {
            GameObject shadow = Instantiate(shadow1, transform.position, Quaternion.identity);
            shadow.GetComponent<PlayerShadow>().TwSpeed = 10 - sh.Count;
            sh.Add(shadow);
        }
    }

    public void LandingDust(GameObject dust)
    {
        Instantiate(dust, new Vector3(transform.position.x-0.05f, transform.position.y-0.45f, 0), Quaternion.identity);
    }
    
    public void JumpingDust()
    {
        Instantiate(JDust, transform.position, Quaternion.identity);
    }

    IEnumerator DelayingAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(WallChk.position, Vector2.right * isRight * WallChkDistance);
    }

    void CheckGroundedState(RaycastHit2D rayHit)
    {
        bool isGrounded = rayHit.collider != null && rayHit.distance < GROUND_CHECK_DISTANCE;
        if (isGrounded)
        { 
            pAnimator.SetBool("Jump", false); 
        }
        else
        {
            if (!isWall) // 떨어지고 있다.
            {
                //그냥 떨어지는중
                pAnimator.SetBool("Jump", true);
            }
            else
            {
                //벽타기
                pAnimator.SetBool("Grab", true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BossScene"))
        {
            SceneManager.LoadScene("Boss");
        }
    }
}