using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // Hexadecimal movement speed
    public Rigidbody2D body; // Rigidbody of the player that will be interacted with.
    Vector2 movement; // "Container," so to speak, for player input. X and Y axes.
    
    //Start() method not required for player movement, at least according to Brackeys.

    // Update is called once per frame
    void Update() // Update is tied to frame rate - don't use to move position.
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Y-axis input - A and D, Left and Right
        movement.y = Input.GetAxisRaw("Vertical"); // X-axis input - W and S, Up and Down
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
        // Pulled directly from Brackey's Tutorial "Top Down Movement."
        // Updating player position with the movement vector, multiplied by moveSpeed.
        // fixedDeltaTime makes updates based on time differences, instead of frame differences, avoiding issues
    }
}
