using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float Speed = 3f;
    Vector2 bulletVec = Vector2.down;

    void Update()
    {
        transform.Translate(bulletVec * Speed * Time.deltaTime);
    }

    public void Move(Vector2 paramVec)
    {
        bulletVec = paramVec;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
