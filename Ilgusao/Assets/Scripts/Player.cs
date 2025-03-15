using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public List<PlayerBullet> Bullets; // 추후 4개 배열로 만들예정
    public Transform Pos = null;
    int bulletIndex;
    bool readyToShoot;
    WaitForSeconds shootInterval;
    Rigidbody2D _rb;
    Animator _anim;

    [SerializeField]
    private GameObject _powerUp;
    void Start()
    {
        _anim = GetComponent<Animator>(); 
        _rb = GetComponent<Rigidbody2D>();
        shootInterval = new WaitForSeconds(0.1f);
        readyToShoot = true;
    }

    void Update()
    {
        float moveX = MoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = MoveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        #region 애니메이션
        if(Input.GetAxis("Horizontal") <= -0.5f)
        { _anim.SetBool("Left", true); }
        else
        { _anim.SetBool("Left", false); }

        if(Input.GetAxis("Horizontal") >= 0.5f)
        { _anim.SetBool("Right", true); }
        else
        { _anim.SetBool("Right", false); }

        if(Input.GetAxis("Vertical") >= 0.5f)
        { _anim.SetBool("Up", true); }
        else
        { _anim.SetBool("Up", false); }
        #endregion

        transform.Translate(moveX, moveY, 0);

        if (Input.GetKey(KeyCode.Space) && readyToShoot)
        {
            StartCoroutine(Shoot());
        }

        _rb.linearVelocity = Vector2.zero;
        
    }
    
    IEnumerator Shoot()
    {
        readyToShoot = false;
        Instantiate(Bullets[bulletIndex], transform.position, Quaternion.identity);
        yield return shootInterval;
        readyToShoot = true;
    }
        

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Item") ) { return; }
        if (bulletIndex < 3)
        {
            ++bulletIndex;
            GameObject powerUp = Instantiate(_powerUp, Vector3.zero, Quaternion.identity);
            Destroy(powerUp, 1);
        }
        Destroy(collision.gameObject);
    }

}
