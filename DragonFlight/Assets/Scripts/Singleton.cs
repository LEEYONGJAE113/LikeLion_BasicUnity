using UnityEngine;

public class Singleton : MonoBehaviour
{
    // 싱글톤 : 하나의 인스턴스만 유지하면서 어디서든 접근 가능하게
    public static Singleton Instance { get; private set; }

    private void Awake() // 게임 오브젝트가 활성화 되기 전 호출
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지되게 함
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void Start() // 게임 오브젝트가 활성화 되고 첫번째 프레임 실행전, 다른 컴포넌트들이 awake 되고 호출
    {
        
    }

    public void PrintMessage()
    {
        Debug.Log("싱글톤 메시지 출력");
    }
}
