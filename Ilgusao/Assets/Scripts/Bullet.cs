using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;

    void Start()
    {

    }

    void Update()
    {
        float yVec = bulletSpeed * Time.deltaTime;
        transform.Translate(0, yVec, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
