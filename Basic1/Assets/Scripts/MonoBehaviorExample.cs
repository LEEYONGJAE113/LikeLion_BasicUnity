using UnityEngine;

public class MonoBehaviorExample : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start : 게임이 시작될 때 호출됩니다.");
    }


    void Update()
    {
        Debug.Log("Update : 프레임마다 호출됩니다.");
        
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate : 물리 프레임마다 호출됩니다.");
    }
}
