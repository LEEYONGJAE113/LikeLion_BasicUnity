using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int attack = 1;


    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().Pos;
    }


    void Update()
    {
        transform.position = pos.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damaged(attack++);
            CreateEffect(collision.transform.position);
        }
        if (collision.CompareTag("Boss"))
        {
            // collision.gameObject.GetComponent<Monster>().Damaged(attack++);
            CreateEffect(collision.transform.position);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damaged(attack++);
            CreateEffect(collision.transform.position);
        }
        if (collision.CompareTag("Boss"))
        {
            // collision.gameObject.GetComponent<Monster>().Damaged(attack++);
            CreateEffect(collision.transform.position);
        }
    }

    void CreateEffect(Vector3 position)
    {
        GameObject eff = Instantiate(effect, position, Quaternion.identity);
        Destroy(eff, 1);
    }
}
