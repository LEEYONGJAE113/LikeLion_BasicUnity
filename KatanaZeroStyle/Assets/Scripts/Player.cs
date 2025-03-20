using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpUp = 27;
    public Vector3 direction;
    public GameObject Slash;


    bool bJump = false;
    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;

    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        KeyInput();
        Move();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (pAnimator.GetBool("Jump") == false)
            {
                Jump();
                pAnimator.SetBool("Jump", true);
            }
        }
    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal"); // -1   0   1

        if(direction.x <0)
        {
            //left
            sp.flipX = true;
            pAnimator.SetBool("Run", true);
        }
        else if(direction.x >0)
        {
            //right
            sp.flipX = false;
            pAnimator.SetBool("Run", true);
        }
        else if(direction.x == 0)
        {
            pAnimator.SetBool("Run", false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            pAnimator.SetTrigger("Attack");
        }

    }

    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Debug.DrawRay(pRig2D.position, Vector3.down, new Color(0, 1, 0));

        // 레이캐스트로 땅체크
        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if(pRig2D.linearVelocityY <= 0 ) // 떨어지는 과정
        {
            if (rayHit.collider != null) // 땅에 닿음
            {
                pAnimator.SetBool("Jump", false);
            }
        }
    }

    public void Jump()
    {
        pRig2D.linearVelocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
    }

    public void SlashAttack()
    {
        Instantiate(Slash, transform.position, Quaternion.identity);

        
    }
}