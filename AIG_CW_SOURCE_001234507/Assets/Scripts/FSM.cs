using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    bool foundPlayer = false;
    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        // do nothing
        //Debug.Log("IDLE :D");
        FindPlayer(enemy);
    }

    public override void ChangeState(EnemyStateMachine enemy) 
    {
        // Change to 
        // Wandering 
        // Chasing if player is spotted

    }

    public void FindPlayer(EnemyStateMachine enemy)
    {
        
        RaycastHit hit;
        if(Physics.Raycast(enemy.frontFacing.position, enemy.frontFacing.forward, out hit, enemy.lookRange))
        {
            Debug.Log(hit.transform.name);
        }
        
        //return foundPlayer;
    }
}

public class Wander : State
{
    bool done = false;

    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        if (!done)
        {
            MoveRandomly(enemy);
        }
    }
    void MoveRandomly(EnemyStateMachine enemy)
    {
        Vector3 randomDestination = Random.insideUnitSphere * enemy.wanderRange;
        enemy.rb.velocity = new(randomDestination.x, enemy.rb.velocity.y, randomDestination.z);
        done = true;

    }



    public override void ChangeState(EnemyStateMachine enemy) 
    {
        // Change state when:
        // Enemy sees player 
        if (done) 
        {
            enemy.currentState = new Idle();
        }

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
