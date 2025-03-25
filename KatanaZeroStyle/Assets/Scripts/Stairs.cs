using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
}
