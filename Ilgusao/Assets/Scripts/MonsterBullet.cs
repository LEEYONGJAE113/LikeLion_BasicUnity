using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float Speed = 4f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
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
