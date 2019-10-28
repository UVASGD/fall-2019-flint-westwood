using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private int numberOfHits;
    [SerializeField] private float bounceDistance;
    [SerializeField] private float damage;

    private Vector3 lastPosition;

    private void Update()
    {

        transform.position += transform.up * moveSpeed * Time.deltaTime;

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.up, bounceDistance);

        if (rayHit)
        {

            Breakable health = rayHit.collider.GetComponent<Breakable>();

            if (health != null && health.ReduceHealth(damage))
            {

                Destroy(health.gameObject);

            }
            else
            {

                transform.up = Vector3.Reflect(transform.up, rayHit.normal);

                numberOfHits--;

                if (numberOfHits <= 0)
                {

                    Destroy(gameObject);

                }

            }

        }

    }

}
