using UnityEngine;

public class LandDust : MonoBehaviour
{
    public float Lifetime = 0.583f;

    void Awake()
    {
        Destroy(gameObject, Lifetime);
    }
}
