using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            // 싱글톤 인스턴스에 접근하여 점수 추가
            GameManager.Instance.AddScore(10);
            Destroy(collision.gameObject);
        }
    }
}
