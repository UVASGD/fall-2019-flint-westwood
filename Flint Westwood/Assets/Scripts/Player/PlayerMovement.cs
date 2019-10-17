using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float playerVelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {

    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * playerVelocity * Time.deltaTime;
        float verticalMovement = Input.GetAxisRaw("Vertical") * playerVelocity * Time.deltaTime;
        Vector2 playerMovement = new Vector2(horizontalMovement, verticalMovement);
        playerRb.velocity = playerMovement;
    }
}
