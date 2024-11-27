using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public abstract class State
{
    public abstract void ExceuteLogic(EnemyStateMachine enemy);
    public abstract void ChangeState(EnemyStateMachine enemy);

}

public class Idle : State
{
    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        // does nothing
    }
    public override void ChangeState(EnemyStateMachine enemy) 
    {
        // Change state when:
        // Enemy sees player 
    }
}

public class Chase : State
{
    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        
    }
    public override void ChangeState(EnemyStateMachine enemy)
    {
        // Change state when:
        // Player is close to enemy 
        // Or when sight is lost of player
    }
}

public class Attack : State 
{
    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        
    }
    public override void ChangeState(EnemyStateMachine enemy)
    {
        // Change state when:
        // Player Dies --> to Idle
        // Player goes out of range and can see the player --> to chase 
    }
}
