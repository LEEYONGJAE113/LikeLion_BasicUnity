using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public List<PlayerBullet> Bullets; // 추후 4개 배열로 만들예정
    public Transform Pos = null;
    public GameObject Lazer;
    GameObject nowLazer;
    int bulletIndex;
    bool readyToShoot;
    bool onLazerMode = false;
    public float gValue = 0f;
    public Image Gage;
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


        if (Input.GetKey(KeyCode.Z) && !onLazerMode)
        {
            nowLazer = Instantiate(Lazer, transform.position, Quaternion.identity);
            onLazerMode = true;
        }

        if (Input.GetKeyUp(KeyCode.Z) && onLazerMode)
        {
            onLazerMode = false;
            Destroy(nowLazer?? null);
        }

        // if(Input.GetKey(KeyCode.Z))
        // {
        //     gValue += Time.deltaTime;
        //     Gage.fillAmount = gValue;

        //     if(gValue >=1)
        //     {
        //         GameObject go = Instantiate(Lazer, transform.position, Quaternion.identity);
        //         Destroy(go, 3);
        //         gValue = 0;
        //     }
        // }
        // else
        // {
        //     gValue -= Time.deltaTime;

        //     if(gValue <=0)
        //     {
        //         gValue = 0;
        //     }


        // }



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
