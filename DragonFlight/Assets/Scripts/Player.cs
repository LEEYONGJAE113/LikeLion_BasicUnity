using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        MoveControl();
        
    }

    void MoveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(distanceX, 0f, 0f); // 약간 미끄러지는 느낌
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
