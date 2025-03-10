using UnityEngine;

public class VectorStudy : MonoBehaviour
{
    // public Vector2 v2 = new Vector2(10, 10);
    // public Vector2 v3 = new Vector3(1, 1, 1);
    void Start()
    {
        Vector3 v3A = new Vector3(1, 1, 0);
        Vector3 v3B = new Vector3(2, 0.5f, 0);

        Vector3 c = v3A + v3B;

        Debug.Log($"Vector {c}");

        Debug.Log($"길이 : {c.magnitude}");

        // 정규화 normalize
        // 벡터의 크기를 1로 만들고 방향만 유지
        Vector3 v3C = new Vector3(3,0,0);
        Vector3 normalizedVector = v3C.normalized;

        Debug.Log($"1의 길이 방향만 정규화하는 벡터 {normalizedVector}");
    }

    void Update()
    {
        
    }
}
