using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject ExplosionEffect;
    public int Attack = 10;
    public float BulletSpeed = 10.0f;

    void Update()
    {
        transform.Translate(Vector2.up * BulletSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damaged(Attack);
            GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
        if (collision.CompareTag("Boss"))
        {
            // collision.gameObject.GetComponent<Boss>().Damaged(Attack);
            GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
        
    }

    
}


