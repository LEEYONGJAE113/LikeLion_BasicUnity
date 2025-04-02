using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;
    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }


    void Update()
    {
        // 키 입력에 따라 이동 전략 변경 Test
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 1키
        {
            _enemy.SetMovementStrategy(new StraightMovement());
            Debug.Log("직선 이동 전략으로 변경");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 숫자 2키
        {
            _enemy.SetMovementStrategy(new ZigZagMovement());
            Debug.Log("지그재그 이동 전략으로 변경");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 숫자 3키
        {
            _enemy.SetMovementStrategy(new CircularMovement());
            Debug.Log("원형 이동 전략으로 변경");
        }
    }
}
