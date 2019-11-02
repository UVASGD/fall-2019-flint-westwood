using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private PlayerMovement player;

    private void Start()
    {

        player = FindObjectOfType<PlayerMovement>();

    }

    private void Update()
    {

        Vector3 playerPosition = player.transform.position;

        transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(playerPosition.y - transform.position.y, playerPosition.x - transform.position.x) * Mathf.Rad2Deg - 90);

        transform.position += transform.up * moveSpeed * Time.deltaTime;

    }

}
