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
    public bool playerFound = false;
    public bool wandering = false;
    public abstract void ExceuteLogic(EnemyStateMachine enemy);
    public abstract void ChangeState(EnemyStateMachine enemy);

    public void FindPlayer(EnemyStateMachine enemy)
    {

        RaycastHit hit;
        if (Physics.Raycast(enemy.frontFacing.position, enemy.frontFacing.forward, out hit, enemy.lookRange))
        {
            //Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Player")
            {
                playerFound = true;
            }
            if(hit.transform.tag == "Untagged" || hit.transform.tag != "Player" )
            {
                playerFound = false;
            }
            
        }

    }


}
public class Idle : State
{
    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        // do nothing
        //Debug.Log("IDLE :D");
        FindPlayer(enemy);
    }

    public override void ChangeState(EnemyStateMachine enemy) 
    {
        // Change to 
        // if player is spotted --> Chase
        if (playerFound) 
        {
            enemy.currentState = new Chase();
        }
        if (!playerFound)
        {
            enemy.currentState = new Wander();
        }
        // Player hasnt been spotted --> Wander
        
       

    }

    
    
}

public class Wander : State
{
    //bool done = false;

    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        
        enemy.MoveRandomlyCoroutine();
    }
    void MoveRandomly(EnemyStateMachine enemy)
    {
        Vector3 randomDestination = Random.insideUnitSphere * enemy.wanderRange;
        enemy.rb.velocity = new(randomDestination.x, enemy.rb.velocity.y, randomDestination.z);
        wandering = true;

    }



    public override void ChangeState(EnemyStateMachine enemy) 
    {
        // Change state when:
        // Enemy hasnt seen player AND finished going to the random spot --> Idle
        if (wandering && !playerFound) 
        {
            enemy.currentState = new Idle();
        }
        // Enemy sees player --> Chase
        if (playerFound)
        {
            enemy.currentState = new Chase();
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
        // Or when sight is lost of player -> Idle
        if (!playerFound)
        {
            enemy.currentState = new Idle();
        }

        // Player is close to enemy --> Attack
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
