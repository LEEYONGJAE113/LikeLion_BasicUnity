using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance =>
    _instance ??= // null이 아닐때 대입
    FindFirstObjectByType<GameManager>() ??
    new GameObject("GameManager").AddComponent<GameManager>();
    // 아주 만족스러움. 별다섯개.

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }


}
