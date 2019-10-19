using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character stats:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("Character attributes:")]
    public float WALK_BASE_SPEED = 1.0f;
    public float SPRINT_BASE_SPEED = 1.5f;

    [Space]
    [Header("Sprint controls:")]
    public float TAP_TIME = 0.5f;

    [Space]
    [Header("References")]
    Animator playerAnim;

    public Rigidbody2D rb;
    
    private bool isSprinting = false;   //True if character currently sprinting

    private float lastTapTime = -1.0f;  //for detecting double tap
    private KeyCode lastKeyPressed = KeyCode.F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if (isSprinting)
        {
            Run();
        }
        else
        {
            Walk();
        }
    }

    void ProcessInputs() 
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f,1.0f);
        movementDirection.Normalize();

        if (Input.GetKeyDown(KeyCode.D))  //CHECKING FOR D DOUBLE TAP
        {
            if(lastKeyPressed == KeyCode.D && Time.time - lastTapTime < TAP_TIME)
            {
                isSprinting = true;
            }

            lastKeyPressed = KeyCode.D;
            lastTapTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.A))  //CHECKING FOR A DOUBLE TAP
        {
            if (lastKeyPressed == KeyCode.A && Time.time - lastTapTime < TAP_TIME)
            {
                isSprinting = true;
            }

            lastKeyPressed = KeyCode.A;
            lastTapTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.S))  //CHECKING FOR S DOUBLE TAP
        {
            if (lastKeyPressed == KeyCode.S && Time.time - lastTapTime < TAP_TIME)
            {
                isSprinting = true;
            }

            lastKeyPressed = KeyCode.S;
            lastTapTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.W))  //CHECKING FOR W DOUBLE TAP
        {
            if (lastKeyPressed == KeyCode.W && Time.time - lastTapTime < TAP_TIME)
            {
                isSprinting = true;
            }

            lastKeyPressed = KeyCode.W;
            lastTapTime = Time.time;
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
        {
            isSprinting = false;
        }

    }

    void Walk()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.velocity = movementDirection * movementSpeed * WALK_BASE_SPEED;
    }

    void Run()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = movementDirection * movementSpeed * SPRINT_BASE_SPEED;
    }
}
