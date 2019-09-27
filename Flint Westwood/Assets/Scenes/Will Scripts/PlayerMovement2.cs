using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D myRB;

    private void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        myRB.position += new Vector2(moveX, moveY) * Time.deltaTime * moveSpeed;
        
    }

}
