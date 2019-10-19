using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private Animator playerAnimator;
    private float playerScale;
    private Rigidbody2D playerRigidbody;

    private void Start()
    {

        playerAnimator = GetComponent<Animator>();

        playerScale = transform.localScale.x;

        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {

            float newPlayerScale = playerScale;

            if (horizontalInput > 0)
            {

                newPlayerScale *= -1;

            }

            transform.localScale = new Vector3(newPlayerScale, playerScale, playerScale);

            Vector3 moveVector = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed;

            playerRigidbody.position += Vector2.ClampMagnitude(moveVector, moveSpeed) * Time.deltaTime;

            playerAnimator.SetBool("moving", true);

        }
        else
        {

            playerAnimator.SetBool("moving", false);

        }

    }

}
