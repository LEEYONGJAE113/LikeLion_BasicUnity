using UnityEngine;

public class IdleState : IState
{
    public void Enter()
    {
        Debug.Log("idle 상태 시작");
    }
    public void Update()
    {
        Debug.Log("idle 상태 유지");
    }
    public void Exit()
    {
        Debug.Log("idle 상태 종료");
    }
}
