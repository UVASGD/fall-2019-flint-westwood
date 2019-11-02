using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character stats:")]
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private float movementSpeed;

    [Space]
    [Header("Character attributes:")]
    [SerializeField] private float WALK_BASE_SPEED = 1.0f;
    [SerializeField] private float SPRINT_BASE_SPEED = 1.5f;
    
    private Rigidbody2D rb;
    private Vector3 playerMovement;
    
    [SerializeField] bool isSprinting = false;   //True if character currently sprinting

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
    }
    
    void FixedUpdate()
    {
        
        HandleMovement();
    }
    

    void ProcessInputs() 
    {
        playerMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        playerMovement = playerMovement.normalized;
        if (Input.GetButton("Sprint"))
        {
            this.isSprinting = true;
            Debug.Log("Sprinting!");
        }
        else
        {
            this.isSprinting = false;
        }
        
    }
    
    void HandleMovement()
    {
        Vector3 playerVelocity;

        if (this.isSprinting)
        {
            playerVelocity = Time.deltaTime * movementSpeed * SPRINT_BASE_SPEED * playerMovement;
        }
        else
        {
            playerVelocity = Time.deltaTime * movementSpeed * WALK_BASE_SPEED * playerMovement;

        }

        rb.MovePosition(transform.position + playerVelocity);
    }
}
