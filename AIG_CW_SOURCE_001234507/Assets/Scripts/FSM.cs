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
                Debug.Log("FOUND");
            }
            //if(hit.transform.tag == "Untagged" || hit.transform.tag != "Player" )
            //{
               
            //    Debug.Log("NOt FOUND");
            //}

        }
        else
        {
            playerFound = false;
            Debug.Log("NOT FOUND");
        }

    }


}


public class Wander : State
{
    //bool done = false;

    public override void ExceuteLogic(EnemyStateMachine enemy)
    {

        enemy.MoveRandomly();
        
    }
    //void MoveRandomly(EnemyStateMachine enemy)
    //{
    //    Vector3 randomDestination = Random.insideUnitSphere * enemy.wanderRange;
    //    enemy.rb.velocity = new(randomDestination.x, enemy.rb.velocity.y, randomDestination.z);
    //    wandering = true;

    //}



    public override void ChangeState(EnemyStateMachine enemy) 
    {
        // Change state when:
       
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
        enemy.ChasePlayer();
    }
    public override void ChangeState(EnemyStateMachine enemy)
    {
        // Change state when:
        // Or when sight is lost of player -> Wander
        if (!playerFound)
        {
            enemy.currentState = new Wander();
        }
        if (enemy.GetIsNearPlayer()) 
        {
            enemy.currentState = new Attack();
        }

        // Player is close to enemy --> Attack
    }
}

public class Attack : State 
{
    public override void ExceuteLogic(EnemyStateMachine enemy)
    {
        enemy.Attack();
    }
    public override void ChangeState(EnemyStateMachine enemy)
    {
        // Change state when:
        // Player Dies --> to Idle
        if (!playerFound) 
        {
            enemy.currentState = new Wander();
        }
        // Player goes out of range and can see the player --> to chase 
        if (!enemy.GetIsNearPlayer()) 
        {
            enemy.currentState = new Chase();
        }
    }
}
