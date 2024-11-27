using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public State currentState;

    [Header("Components")]
    public Rigidbody rb;
    public Transform groundCheck;

    [Header("Ground Check")]
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [Header("Floats")]
    public float walkSpeed = 2f;
    public float wanderRange = 10;

    [Header("Booleans")]
    [SerializeField] private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        currentState = new Wander();

    }

    // Update is called once per frame
    void Update()
    {
        currentState.ExceuteLogic(this);
        currentState.ChangeState(this);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        
    }
}
