using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Hp = 100;
    public float Speed = 1f;
    public float Delay = 1f;
    public Transform Ms1;
    public Transform Ms2;
    public GameObject Bullet;
    public Item item;
    void Start()
    {
        // 한번 호출
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(Bullet, Ms1.position, Quaternion.identity);
        Instantiate(Bullet, Ms2.position, Quaternion.identity);

        Invoke("CreateBullet", Delay); // 재귀호출
    }

    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        // PoolManager.Instance.Return(gameObject);
    }

    public void Damaged(int attack)
    {
        Hp -= attack;

        if (Hp <= 0)
        {
            DropRandomItem();
            Destroy(gameObject);
            // PoolManager.Instance.Return(gameObject);
        }

    }

    void DropRandomItem()
    {
        int randInt = Random.Range(0,3);
        if (randInt != 0) { return; }
        Instantiate(item, transform.position, Quaternion.identity);
    }


}
