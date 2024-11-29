using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public State currentState;

    [Header("Components")]
    public Rigidbody rb;
    public Transform groundCheck;
    public Transform frontFacing;
    public Transform playerTransform;
    public GameObject attackSphere;

    [Header("Ground Check")]
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [Header("Player Check")]
    [SerializeField] private float playerCheckDistance = 1f;
    [SerializeField] private LayerMask playerCheckMask;

    [Header("Floats")]
    public float walkSpeed = 2f;
    public float wanderRange = 10;
    public float rotationSpeed = 150f;
    public float lookRange = 10;

    [Header("Booleans")]
    [SerializeField] private bool isGrounded;
    private bool isWandering = false;
    private bool isWalking = false;
    private bool rRight = false;
    private bool rLeft = false;
    private bool attacking = false;
    [SerializeField] private float attackTime = 1.5f;
    private bool isNearPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        
        currentState = new Wander();

       
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log(currentState.ToString());

        currentState.ExceuteLogic(this);
        currentState.ChangeState(this);
        currentState.FindPlayer(this);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isNearPlayer = Physics.CheckSphere(attackSphere.transform.position, playerCheckDistance, playerCheckMask);
        
    }


    IEnumerator Wander()
    {
        int walkTime = Random.Range(1, 3);
        int waitTime = Random.Range(1, 4);
        int rotationTime = Random.Range(1, 2);
        int rotateRorL = Random.Range(1, 2);
        //int rotationCompleteTime = Random.Range(1, 4);

        isWandering = true;

        yield return new WaitForSeconds(waitTime);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        if(rotateRorL == 1)
        {
            rRight = true;
            yield return new WaitForSeconds(rotationTime);
            rRight = false;
        }
        if (rotateRorL == 2)
        {
            rLeft = true;
            yield return new WaitForSeconds(rotationTime);
            rLeft = false;
        }


        isWandering = false;
    }

    public void MoveRandomly()
    {
        
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
        if (rLeft) 
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);

        }
        if (rRight) 
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isWalking) 
        {
            transform.position += frontFacing.forward * walkSpeed * Time.deltaTime;
        }

    }

    public void ChasePlayer()
    {
        //transform.rotation = Quaternion.Slerp(frontFacing.rotation, Quaternion.LookRotation(playerTransform.position - frontFacing.position), rotationSpeed * Time.deltaTime);
        transform.position += frontFacing.forward * Time.deltaTime * walkSpeed;
    }
    IEnumerator AttackPlayer()
    {
        attacking = true;
        yield return new WaitForSeconds(attackTime);
        attacking = false;  
    }

    public void Attack()
    {
        if (attacking) 
        {
            attackSphere.SetActive(true);
        }
        if (!attacking)
        {
            attackSphere.SetActive(false);
            StartCoroutine (AttackPlayer());
        }
    }
    public bool GetIsWandering()
    {
        return isWandering;
    }

    public bool GetIsNearPlayer()
    {
        return isNearPlayer;
    }

}
