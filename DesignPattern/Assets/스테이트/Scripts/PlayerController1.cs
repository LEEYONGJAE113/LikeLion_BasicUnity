using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private StateMachine stateMachine;

    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState()); // 초기 idle 상태
    }


    void Update()
    {
        stateMachine.Update();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(new JumpState());
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.ChangeState(new RunState());
        }
        else if (!Input.anyKey) // 아무키도 안 누름
        {
            stateMachine.ChangeState(new IdleState());
        }
    }
}
