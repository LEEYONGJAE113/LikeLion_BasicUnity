using UnityEngine;

public class Item : MonoBehaviour
{
    // 아이템 가속 속도
    public float ItemVelocity = 100f;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }

    void Update()
    {
        
    }
}
