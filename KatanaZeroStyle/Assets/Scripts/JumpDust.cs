using UnityEngine;

public class JumpDust : MonoBehaviour
{
    public float Lifetime = 0.333f;

    void Awake()
    {
        Destroy(gameObject, Lifetime);
    }
}
