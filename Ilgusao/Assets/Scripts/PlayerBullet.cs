using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject ExplosionEffect;
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
            collision.gameObject.GetComponent<Monster>().Damaged(1);
            GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
        if (collision.CompareTag("Boss"))
        {
            // collision.gameObject.GetComponent<Boss>().Damaged(1);
            GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
        
    }

    
}


