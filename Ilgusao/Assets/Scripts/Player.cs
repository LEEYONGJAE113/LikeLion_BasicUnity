using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    Rigidbody2D _rb;
    Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>(); 
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = MoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = MoveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

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

        transform.Translate(moveX, moveY, 0);

        _rb.linearVelocity = Vector2.zero;
    }
}
